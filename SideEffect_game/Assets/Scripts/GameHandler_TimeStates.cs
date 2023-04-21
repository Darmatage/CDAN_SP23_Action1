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


	void Awake(){
		playerOBJ = GameObject.FindWithTag("Player");
		mainCamera = Camera.main;
		//cameraFutureColor = new Color (0.6f, 0.65f, 0.85f, 0f);
		//cameraPastColor = new Color (1.6f, 1.6f, 1.3f, 0f);
	}

    void Start(){
		if (isPast==true){
			goToPast();
		} else {
			goToFuture();
		}
    }

	void Update(){
		if ((Input.GetKeyDown("t"))&&(GameHandler_TimeStates.canTimeSwitch==true)){
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
		musicPast.Play();
		musicFuture.Stop();
		NPCs_Past.SetActive(true);
		NPCs_Future.SetActive(false);
	}
	
	public void goToFuture(){
		isPast = false;
		BG_Future.SetActive(true);
		BG_Past.SetActive(false);
		mainCamera.backgroundColor = cameraFutureColor;
		ChangeObjects();
		musicPast.Stop();
		musicFuture.Play();
		NPCs_Past.SetActive(false);
		NPCs_Future.SetActive(true);
	}
	
	
	public void ChangeObjects(){
		foreach (Obstacle_TimeState obst in obstacles) {
            obst.SetTime();
        }
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
	
	
	
	
	
