using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalendarDisplay : MonoBehaviour {

	//public GameObject msg_pressE;
	public GameObject calendarImage;
	//private bool canDisplay = false;
	//private bool isOnDisplay = false;

	void Start (){
		//msg_pressE.SetActive(false);
		calendarImage.SetActive(false);
	}

	void Update (){
		/*
		if ((Input.GetKeyDown("e"))&&(canDisplay)){
			if (isOnDisplay==false){
				calendarImage.SetActive(true);
				isOnDisplay = true;
			} else {
				calendarImage.SetActive(false);
				isOnDisplay = false;
			}
		}*/
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag=="Player"){
			calendarImage.SetActive(true); //this line is for the non-msg version. Hide if using message!
			//msg_pressE.SetActive(true);
			//canDisplay = true;
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.tag=="Player"){
			//msg_pressE.SetActive(false);
			//canDisplay = false;
			calendarImage.SetActive(false);
			//isOnDisplay = false;
		} 
	}
}