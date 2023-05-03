using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public GameObject target;
	public float camSpeed = 4.0f;

	public float offsetY = 10f;
	private float theOffsetY;

	void Start(){
		target = GameObject.FindWithTag("Player");
		theOffsetY = offsetY;
	}

	void FixedUpdate () {
			Vector2 targetWithOffset = new Vector2(target.transform.position.x, target.transform.position.y + theOffsetY);
			Vector2 pos = Vector2.Lerp ((Vector2)transform.position, targetWithOffset, camSpeed * Time.fixedDeltaTime);
            //Vector2 pos = Vector2.Lerp ((Vector2)transform.position, (Vector2)target.transform.position, camSpeed * Time.fixedDeltaTime);
            transform.position = new Vector3 (pos.x, pos.y, transform.position.z);
	}
	
	
	public void JumpReset(){
		theOffsetY = 0;
		StartCoroutine(OffsetBack());
	}
	
	IEnumerator OffsetBack(){
		yield return new WaitForSeconds (0.5f);
		theOffsetY = offsetY;
	}
	
}