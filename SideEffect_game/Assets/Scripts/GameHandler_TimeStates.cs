using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler_TimeStates : MonoBehaviour{

	//public string thisScene;
	public static bool canTimeSwitch = true; // add timer so the player cannot just do it whenever!
	public static Vector3 playerLocation;
	private GameObject playerOBJ;

	public static bool isPast = false;
	public bool makeIsPast = false;

	//Environment
	public GameObject BG_Future;
	public GameObject BG_Past;
	private Camera mainCamera;
	public Color cameraFutureColor;
	public Color cameraPastColor;
	
	//Objects
	public Obstacle_TimeState[] obstacles;

	//NPCs
	public GameObject NPCs_Past;
	public GameObject NPCs_Future;

	//music
	public AudioSource musicPast;
	public AudioSource musicFuture;
	private float stopPastTimestamp = 0.0f;
	private float stopFutureTimestamp = 0.0f;

	//deadBatteries
	public bool timeMachineDead = false;
	public GameObject timemachineCover;

	void Awake(){
		playerOBJ = GameObject.FindWithTag("Player");
		mainCamera = Camera.main;
		//cameraFutureColor = new Color (0.6f, 0.65f, 0.85f, 0f);
		//cameraPastColor = new Color (1.6f, 1.6f, 1.3f, 0f);
	}

    void Start(){
		if (makeIsPast==true){
			isPast = true;
		}
		if (isPast==true){
			goToPast();
		} else {
			goToFuture();
		}
		
		if (timeMachineDead == false){timemachineCover.SetActive(false);}
		else {timemachineCover.SetActive(true);}
    }


	void Update(){
		if ((Input.GetKeyDown("t"))&&(canTimeSwitch==true)&&(timeMachineDead == false)){
			if (isPast == false){
				goToPast();
			} else {
				goToFuture();
			}
		}  
    }
	
	public void SwitchTime(){
		if (canTimeSwitch==true){
			if (isPast == false){
				goToPast();
			} else {
				goToFuture();
			}
		}
	}
	
	
	public void goToPast(){
		isPast = true;
		BG_Future.SetActive(false);
		BG_Past.SetActive(true);
		mainCamera.backgroundColor = cameraPastColor;
		ChangeObjects();
		StopMusic("future");
		PlayMusicAtTime("past");
		NPCs_Past.SetActive(true);
		NPCs_Future.SetActive(false);
	}
	
	public void goToFuture(){
		isPast = false;
		BG_Future.SetActive(true);
		BG_Past.SetActive(false);
		mainCamera.backgroundColor = cameraFutureColor;
		ChangeObjects();
		StopMusic("past");
		PlayMusicAtTime("future");
		NPCs_Past.SetActive(false);
		NPCs_Future.SetActive(true);
	}

	public void ChangeObjects(){
		foreach (Obstacle_TimeState obst in obstacles) {
            obst.SetTime();
        }
    }

	//Music Management
	public void PlayMusicAtBegin(string timeZone){
		if (timeZone == "past"){
			musicPast.time = 0.0f;
			musicPast.Play();
		} else if (timeZone == "future"){
			musicFuture.time = 0.0f;
			musicFuture.Play();
		}
	}

	public void StopMusic(string timeZone){
		if (timeZone == "past"){
			stopPastTimestamp = musicPast.time;
			Debug.Log("Stopped Past audio at: " + stopPastTimestamp);
			musicPast.Stop();
		}
		else if (timeZone == "future"){
			stopFutureTimestamp = musicFuture.time;
			Debug.Log("Stopped Future audio at: " + stopFutureTimestamp);
			musicFuture.Stop();
		}
	}

	public void PlayMusicAtTime(string timeZone){
		if  (timeZone == "past"){
			if (stopFutureTimestamp > musicPast.clip.length){
				return;
			} else {
				musicPast.time = stopFutureTimestamp;
				musicPast.Play();
			}
		}
		else if  (timeZone == "future"){
			if (stopPastTimestamp > musicFuture.clip.length){
				return;
			} else {
				musicFuture.time = stopPastTimestamp;
				musicFuture.Play();
			}
		}
	}
	
	public void depowerTimeMachine(){
		timeMachineDead = true;
		timemachineCover.SetActive(true);
	}
	
	
	
	public void repowerTimeMachine(){
		timeMachineDead = false;
		timemachineCover.SetActive(false);
	}
	

	
}

	// one-way colliding platforms:
	//https://youtu.be/M_kg7yjuhNg
	
	
	
		/*
	//TWO-SCENE VERSION: VARIABLES
	// Level 1
	public static bool  Level1_new = true;
	
	// Level 2
	public static bool  Level2_new = true;
	
	// Level 3
	public static bool  Level3_new = true;
	
	// Level 4
	public static bool  Level4_new = true;

	// Jason Test Level
	public static bool JasonTest_new = true;
	public static Vector3 JWtest_box1;
	public static Vector3 JWtest_box2;
	*/
	
	
	/*
		//TWO SCENE VERSION: AWAKE
		thisScene = SceneManager.GetActiveScene().name;
		
		//this needs to be in awake, so player_timestate can change the new-test in Start()
		if ((thisScene=="JasonTest_future")||(thisScene=="JasonTest_past")){
			if (JasonTest_new == true){
				playerLocation = playerOBJ.transform.position;
				Debug.Log("Player Location, new: " + playerLocation);
			} else {
				playerOBJ.transform.position = new Vector3(playerLocation.x, playerLocation.y, 0);
				Debug.Log("Player Location, new: " + playerOBJ.transform.position);
			}
		}
	*/
	
	
	
	
	
