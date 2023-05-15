using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PickUp : MonoBehaviour{

      private GameHandler gameHandler;
      //public playerVFX playerPowerupVFX;
      public bool isHealthPickUp = true;
      public bool isKey = false;
	  public bool isScrewdriver = false;
	  public bool isTrap = false;
	  public bool isMachinePart1 = false;
	  public bool isMachinePart2 = false;
	  //public bool isMachinePart3 = false;
	 // public AudioSource PickUpSFX;
	 
	 //since the sound effect doesn't want to fucking work I guess we're not doing it. piece of shit.
	  

      public int healthBoost = 50;


      void Start(){
            gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
            //playerPowerupVFX = GameObject.FindWithTag("Player").GetComponent<playerVFX>();
      }

      public void OnTriggerEnter2D (Collider2D other){
            if (other.gameObject.tag == "Player"){
                  GetComponent<Collider2D>().enabled = false;
                  //GetComponent<AudioSource>().Play();
                  StartCoroutine(DestroyThis());

                  if (isHealthPickUp == true) {
                        gameHandler.playerGetHit(healthBoost * -1);
                        //playerPowerupVFX.powerup();
                  }


                  if (isKey == true) {
                        gameHandler.GetComponent<GameInventory>().InventoryAdd("item1");
                        //playerPowerupVFX.powerup();
                  }

                  if (isScrewdriver == true) {
                        gameHandler.GetComponent<GameInventory>().InventoryAdd("item2");
                        //playerPowerupVFX.powerup();
                  }
				  
                  if (isMachinePart1 == true) {
                        gameHandler.GetComponent<GameInventory>().InventoryAdd("item3");
                        //playerPowerupVFX.powerup();
                  }

                  if (isMachinePart2 == true) {
                        gameHandler.GetComponent<GameInventory>().InventoryAdd("item4");
                        //playerPowerupVFX.powerup();
                  }		

				if (isTrap == true) {
                        gameHandler.GetComponent<GameInventory>().InventoryAdd("item5");
                        //playerPowerupVFX.powerup();
                  }					  


                 // if (isSpeedBoostPickUp == true) {
                 //       other.gameObject.GetComponent<PlayerMove>().speedBoost(speedBoost, speedTime);
                        //playerPowerupVFX.powerup();
                 // }
            }
      }

      IEnumerator DestroyThis(){
            yield return new WaitForSeconds(0.3f);
            Destroy(gameObject);
      }

}