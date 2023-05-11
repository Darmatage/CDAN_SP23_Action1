using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacle_TimeState : MonoBehaviour{
	
	public GameObject artPast;
	public GameObject artFuture;
	
	private Rigidbody2D rb2D;
	
	public bool isMoveable = true;
	
	void Awake(){
		rb2D = transform.GetComponent<Rigidbody2D>();
	}

	void Start(){
		//set initial time state per the GameHandler
		SetTime();
	}

	//this function is activated by the GameHandler to set the time
    public void SetTime(){
		if (GameHandler_TimeStates.isPast == true){
			artPast.SetActive(true);
			artFuture.SetActive(false);
			rb2D.bodyType = RigidbodyType2D.Dynamic;
		} else {
			artPast.SetActive(false);
			artFuture.SetActive(true);
			rb2D.bodyType = RigidbodyType2D.Static;
		}
    }
	
	//make moveable objects stop as soon as they are released
	void OnCollisionExit2D(Collision2D colExt){
		if (GameHandler_TimeStates.isPast == true){
			gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
			if ((colExt.gameObject.GetComponent<Rigidbody2D>() != null) && (colExt.gameObject.GetComponent<Rigidbody2D>().bodyType ==RigidbodyType2D.Dynamic))
			{
				colExt.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
			}
		}
	}
	
}


	//TWO-SCENE VERSION: VARIABLES
	//public bool isPast = false;
	//public string thisScene;
	//public string thisObjectName;
	
	//TWO-SCENE VERSION: AWAKE
	//thisScene = SceneManager.GetActiveScene().name;
	