using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHandler_TravelTimer : MonoBehaviour{
	public float timerMax = 10f;       //set the number of seconds here
	private float theTimer = 0f;
	//public bool doTheThing = false;

	public Image timerCircleDisplay;

	void Start(){
           //timerCircleDisplay.gameObject.SetActive(false);
           theTimer = timerMax;
	}

/*
	void Update(){
            //test functionality. Normally set=true by external script.
            if (Input.GetKeyDown("8")){
                  doTheThing = true;
            }
	}
*/
	void FixedUpdate(){
		if (GameHandler_TimeStates.isPast == true){
			theTimer -= 0.01f;
			//Debug.Log("time: " + theTimer);
			timerCircleDisplay.gameObject.SetActive(true);
			timerCircleDisplay.fillAmount = theTimer / timerMax;

			if (theTimer <= 0){
				GetComponent<GameHandler_TimeStates>().goToFuture();
				Debug.Log("I am pulled to the future!");
				//theTimer = timerMax;
				//can be replaced with the desired commands
				
				//doTheThing = false;
			}
		} else {
			if (theTimer < timerMax){
				theTimer += 0.01f;
				//Debug.Log("time: " + theTimer);
				timerCircleDisplay.gameObject.SetActive(true);
				timerCircleDisplay.fillAmount = theTimer / timerMax;
			}
		}
	}

	/*
       //public function to be accessed by other scripts to activate the timer.
       public void TimeToDoTheThing(){
              doTheThing = true;
              //other commands when turnign on timer can go here.
       }*/
} 