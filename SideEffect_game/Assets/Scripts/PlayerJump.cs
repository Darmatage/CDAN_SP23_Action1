using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerJump : MonoBehaviour {

      //public Animator anim;
      private Rigidbody2D rb;
      public float jumpForce = 10f;
      public Transform feet;
      public LayerMask groundLayer;
      public LayerMask enemyLayer;
      public bool canJump = false;
      public int jumpTimes = 0;
      public bool isAlive = true;
      public AudioSource JumpSFX;

      void Start(){
            //anim = gameObject.GetComponentInChildren<Animator>();
            rb = GetComponent<Rigidbody2D>();
      }

	void Update() {
		if ((IsGrounded()) || (jumpTimes < 1)){ //normally should be <= 1, but first jump is not updating jumpTimes
			canJump = true;
		}  else if (jumpTimes > 0){ //normally should be >1, but first jump is not updating jumpTimes
			canJump = false;
		}

		if ((Input.GetButtonDown("Jump")) && (canJump) && (isAlive == true)) {
			Jump();
			GameObject.FindWithTag("MainCamera").GetComponent<CameraFollow>().JumpReset();
		}
	}

      public void Jump() {
            rb.velocity = Vector2.up * jumpForce;
			jumpTimes += 1;
            // anim.SetTrigger("Jump");
            JumpSFX.Play();

            //Vector2 movement = new Vector2(rb.velocity.x, jumpForce);
            //rb.velocity = movement;
      }

      public bool IsGrounded() {
            Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 1f, groundLayer);
            Collider2D enemyCheck = Physics2D.OverlapCircle(feet.position, 1f, enemyLayer);
            if ((groundCheck != null) || (enemyCheck != null)) {
                  //Debug.Log("I am trouching ground!");
                  jumpTimes = 0;
                  return true;
            }
            return false;
      }
}
