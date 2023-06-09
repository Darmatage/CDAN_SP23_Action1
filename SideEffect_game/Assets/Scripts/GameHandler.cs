using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameHandler : MonoBehaviour {

	private GameObject player;
	public static int playerHealth = 100;
	public int StartPlayerHealth = 100;
	public GameObject healthText;

	//public static int gotTokens = 0;
	//public GameObject tokensText;

	public bool isDefending = false;

	public static bool stairCaseUnlocked = false;
      //this is a flag check. Add to other scripts: GameHandler.stairCaseUnlocked = true;

	private string sceneName;
	public static string replaySceneDeath = "Level_3";

	//Pause menu
	public static bool GameisPaused = false;
	public GameObject pauseMenuUI;
	public AudioMixer mixer;
	public static float volumeLevel = 0.5f;
	private Slider sliderVolumeCtrl;

	void Awake (){
		SetLevel (volumeLevel);
		GameObject sliderTemp = GameObject.FindWithTag("PauseMenuSlider");
		if (sliderTemp != null){
			sliderVolumeCtrl = sliderTemp.GetComponent<Slider>();
			sliderVolumeCtrl.value = volumeLevel;
		}
	}

	void Start(){
            player = GameObject.FindWithTag("Player");
            sceneName = SceneManager.GetActiveScene().name;
            //if (sceneName=="MainMenu"){ //uncomment these two lines when the MainMenu exists
                  playerHealth = StartPlayerHealth;
            //}
            updateStatsDisplay();
		
		//pause menu
		pauseMenuUI.SetActive(false);
		GameisPaused = false;
	}

	void Update (){
		if (Input.GetKeyDown(KeyCode.Escape)){
			if (GameisPaused){
				Resume();
			}
			else{
				Pause();
			}
		}
	}

	void Pause(){
		pauseMenuUI.SetActive(true);
		Time.timeScale = 0f;
		GameisPaused = true;
	}

	public void Resume(){
		pauseMenuUI.SetActive(false);
		Time.timeScale = 1f;
		GameisPaused = false;
	}

	public void SetLevel (float sliderValue){
		mixer.SetFloat("MusicVolume", Mathf.Log10 (sliderValue) * 20);
		volumeLevel = sliderValue;
	} 

	/*
      public void playerGetTokens(int newTokens){
            gotTokens += newTokens;
            updateStatsDisplay();
      }
	  */

      public void playerGetHit(int damage){
           if (isDefending == false){
                  playerHealth -= damage;
                  if (playerHealth >=0){
                        updateStatsDisplay();
                  }
                  if (damage > 0){
                        player.GetComponent<PlayerHurt>().playerHit();       //play GetHit animation
                  }
            }

           if (playerHealth > StartPlayerHealth){
                  playerHealth = StartPlayerHealth;
                  updateStatsDisplay();
            }

           if (playerHealth <= 0){
                  playerHealth = 0;
                  updateStatsDisplay();
                  playerDies();
            }
	}

	public void updateStatsDisplay(){
		Text healthTextTemp = healthText.GetComponent<Text>();
		healthTextTemp.text = "HEALTH: " + playerHealth;

		//Text tokensTextTemp = tokensText.GetComponent<Text>();
		//tokensTextTemp.text = "GOLD: " + gotTokens;
	}

	public void playerDies(){
		player.GetComponent<PlayerHurt>().playerDead();       //play Death animation
		StartCoroutine(DeathPause());
	}

	IEnumerator DeathPause(){
		player.GetComponent<PlayerMove>().isAlive = false;
		player.GetComponent<PlayerJump>().isAlive = false;
		yield return new WaitForSeconds(1.0f);
		replaySceneDeath = sceneName; //allows replaying the scene where you died
		SceneManager.LoadScene("YouDied");
	}

	public void StartGame() {
		SceneManager.LoadScene("Level_1");
	}

	public void RestartGame() {
		Time.timeScale = 1f;
		SceneManager.LoadScene("MainMenu");
		// Please also reset all static variables here, for new games!
		playerHealth = StartPlayerHealth;
	}

	public void ReplayLevel() {
		Time.timeScale = 1f;
		SceneManager.LoadScene(replaySceneDeath);
		// Please also reset all static variables here, for new games!
		playerHealth = StartPlayerHealth;
	}

	public void QuitGame() {
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Quit();
		#endif
	}

	public void Credits() {
		SceneManager.LoadScene("Credits");
	}
}