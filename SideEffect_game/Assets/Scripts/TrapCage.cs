using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapCage : MonoBehaviour{

	public GameObject cage;
	public Transform raisedPos;
	public Transform downPos;

    void Start(){
        cage.transform.position = raisedPos.position;
    }



    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "Enemies"){
			cage.transform.position = downPos.position;
			Debug.Log("Cage is down");
		}
    }
}
