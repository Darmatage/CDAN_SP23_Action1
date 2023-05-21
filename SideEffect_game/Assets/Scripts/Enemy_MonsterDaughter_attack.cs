using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_MonsterDaughter_attack : MonoBehaviour{
     //NOTE: this script moves right-ward by default, but turn on isVertical to move upward;
       public float moveDelay = 2f;
       public float moveRate = 10f;
       public bool isVertical = false;
       public bool startMove = false;
       public float moveTimer = 0;
       private Rigidbody2D rb2D;
       public Vector2 forceVector;
	   public bool isAttacking = false;
	   public int damageEnter = 5;
	   public int damageInside = 1;
	   private bool isInsideDamage = false;
	   public float dmgRate = 0.5f;
	   private float dmgTimer;
	   private GameHandler gameHandler;
	   public LayerMask groundLayer;
	   
	   private float minHeight = 2f;
       //public GameObject startDoomEffect; //uncomment to spawn a spritesheet or particles on move start
       //private Animator anim; //uncomment for animated wall (rotating spike wheels, roiling fire or lava, etc)
       //public AudioSource startSFX;

       void Start(){
		   gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
		   dmgTimer = dmgRate;
              rb2D = gameObject.GetComponent<Rigidbody2D>();
              //anim = gameObject.GetComponentInChildren<Animator>();
       }

       void FixedUpdate(){
              moveTimer += 0.01f;
              if (moveTimer >= moveDelay){
                     startMove = true;
                     //GameObject startMove = Instantiate (startDoomEffect, transform.position, transform.rotation);
                     //anim.SetBool("deathmotion", true);
                     //startSFX.Play();
              }

              if (startMove == true){
                     float moveForce = moveRate * Time.deltaTime;
                     if (isVertical == false){
                            forceVector = new Vector2(moveForce, 0);
							if (transform.position.y < minHeight){
								transform.position = new Vector2(transform.position.x, 2f);
							}
                     } else if (isVertical == true) {
                            forceVector = new Vector2(0, moveForce);
                     }
                     rb2D.velocity = forceVector;
              }
			
		if (isInsideDamage == true){
			if (dmgTimer > 0){
				dmgTimer -= 0.01f;     
			}
			else {
				DoDamage(damageInside);
				dmgTimer = dmgRate;
			}
		}
			  
	}
	   
	public void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.layer == 6){
			rb2D.isKinematic = true;
		}
	}   
	   
	public void OnTriggerEnter2D(Collider2D other){
              if (other.gameObject.tag == "Player") {
                     isAttacking = true;
                     //anim.SetBool("attack", true);
                     DoDamage(damageEnter);
              }
	}

	public void OnTriggeStay2D(Collider2D other){
              if (other.gameObject.tag == "Player") {
                     //isAttacking = true;
					 isInsideDamage = true;
              }
	}

	public void OnTriggerExit2D(Collider2D other){
              if (other.gameObject.tag == "Player") {
                     isAttacking = false;
					 isInsideDamage = false;
                     //anim.SetBool("attack", false);
              }
	}
	   
	public void DoDamage(int dmgAmt){
		   gameHandler.playerGetHit(dmgAmt);
	}
	  
}
