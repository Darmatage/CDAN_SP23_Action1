using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class NPCDialogueManager : MonoBehaviour {

       public GameObject dialogueBox;
       public Text dialogueTextChar1;
	   public Text dialogueTextChar2;
	   
	   public GameObject displayChar1;
	   public GameObject displayChar2;
	   public Image NPCArt;
	   public Sprite[] NPC_Choices;
	   //NOTE: we should make a char2+ display for all freindly NPCs the player can speak with 
	   //and an int for which character it is
	   private bool isOtherChar=true;
	   
	   
       public string[] dialogue;
       public int counter = 0;
       public int dialogueLength;

	void Start(){
		dialogueBox.SetActive(false);
		dialogueLength = dialogue.Length; //allows us test dialogue without an NPC
	}

       void Update(){
              //temporary testing before NPC is created
              if (Input.GetKeyDown("o")){
                     dialogueBox.SetActive(true);
              }
              if (Input.GetKeyDown("p")){
                     dialogueBox.SetActive(false);
                     dialogueTextChar1.text = "..."; //reset text
					 dialogueTextChar2.text = "..."; //reset text
                     counter = 0; //reset counter
              }
			  
			  if (isOtherChar==true){
				  displayChar1.SetActive(false);
				  displayChar2.SetActive(true);
			  } else {
				  displayChar1.SetActive(true);
				  displayChar2.SetActive(false);
			  }
			  
       }

	public void ChooseNPC(int thisNPC){
		NPCArt.sprite = NPC_Choices[thisNPC];
	}

	public void OpenDialogue(){
		isOtherChar=true;
		dialogueBox.SetActive(true);
 
		//auto-loads the first line of dialogue
		dialogueTextChar1.text = dialogue[0];
		dialogueTextChar2.text = dialogue[0];
		counter = 1;
	}

	public void CloseDialogue(){
              dialogueBox.SetActive(false);
              dialogueTextChar1.text = "..."; //reset text
			  dialogueTextChar2.text = "..."; //reset text
              counter = 0; //reset counter
       }

       public void LoadDialogueArray(string[] NPCscript, int scriptLength){
              dialogue = NPCscript;
              dialogueLength = scriptLength;
       }

        //function for the button to display next line of dialogue
	public void DialogueNext(){
		if (counter < dialogueLength){
			isOtherChar = !isOtherChar;
			dialogueTextChar1.text = dialogue[counter];
			dialogueTextChar2.text = dialogue[counter];
			counter +=1;
		}
		else { //when lines are complete:
			dialogueBox.SetActive(false); //turn off the dialogue display
			dialogueTextChar1.text = "..."; //reset text
			dialogueTextChar2.text = "..."; //reset text
			counter = 0; //reset counter
		}
	}

}