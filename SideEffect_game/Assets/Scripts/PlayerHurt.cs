using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerHurt: MonoBehaviour{

      //public Animator animator;
      public Rigidbody2D rb2D;
	  public AudioSource HurtSFX;

      void Start(){
           //animator = gameObject.GetComponentInChildren<Animator>();
           rb2D = transform.GetComponent<Rigidbody2D>();           
      }

      public void playerHit(){
            //animator.SetTrigger ("GetHurt");
			HurtSFX.Play();
      }

      public void playerDead(){
            rb2D.isKinematic = true;
            //animator.SetTrigger ("Dead");
      }
}