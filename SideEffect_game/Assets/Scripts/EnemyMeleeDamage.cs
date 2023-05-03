using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class EnemyMeleeDamage : MonoBehaviour {
       private Renderer rend;
       private Animator anim;
       public GameObject healthLoot;
       public int maxHealth = 100;
       public int currentHealth;

       void Start(){
              rend = GetComponentInChildren<Renderer> ();
              anim = GetComponentInChildren<Animator> ();
              currentHealth = maxHealth;
       }

       public void TakeDamage(int damage){
              currentHealth -= damage;
              rend.material.color = new Color(2.4f, 0.9f, 0.9f, 1f);
              StartCoroutine(ResetColor());
              anim.SetTrigger ("getHurt");
              if (currentHealth <= 0){
                     Die();
              }
       }

       void Die(){
              Instantiate (healthLoot, transform.position, Quaternion.identity);
              anim.SetTrigger ("KO");
              GetComponent<Collider2D>().enabled = false;
              StartCoroutine(Death());
       }

       IEnumerator Death(){
              yield return new WaitForSeconds(0.5f);
              Debug.Log("You Killed a baddie. You deserve loot!");
              Destroy(gameObject);
       }

       IEnumerator ResetColor(){
              yield return new WaitForSeconds(0.5f);
              rend.material.color = new Color(2.55f, 2.55f, 2.55f, 1f);
       }
}