using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class LockedDoor : MonoBehaviour{

      private GameHandler gameHandler;
      public GameObject doorLocked;
      public GameObject doorOpened;
	  public GameObject msg_needKey;
	  private bool isLocked = true; 
	  public Collider2D lockedCollider;

      void Start(){
            gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
            doorLocked.SetActive(true);
            doorOpened.SetActive(false);
			msg_needKey.SetActive(false);
      }

	public void OnCollisionEnter2D (Collision2D other){
		if(other.gameObject.tag == "Player"){
			Debug.Log("i see you, player collider!");
			if(isLocked == true){
				if (GameInventory.item1num > 0) {
					doorLocked.SetActive(false);
					doorOpened.SetActive(true);
					isLocked = false;
					lockedCollider.enabled = false;
					//GetComponent<AudioSource>().Play();						
					gameHandler.GetComponent<GameInventory>().InventoryRemove("item1", 1);
				}
			}
		}
	}


	public void OnTriggerEnter2D (Collider2D other){
		if((other.gameObject.tag == "Player")&&(isLocked == true)){
			if (GameInventory.item1num <= 0){
				msg_needKey.SetActive(true);
				//Debug.Log("You need a key to enter.");
			}
		}
	}
	  
	public void OnTriggerExit2D (Collider2D other){
		if(other.gameObject.tag == "Player"){
			msg_needKey.SetActive(false);
		}
	}

}