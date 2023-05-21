using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonsTween_AlphaMove : MonoBehaviour{
	public AnimationCurve curveMove = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);
	public AnimationCurve curveAlpha = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);
	float elapsed = 0f;
	float elapsedMove = 0f;
	
//content to fade alpha:
	Image thisImage;
	private TextMeshProUGUI buttonText;
	//private Text buttonText;

//Which button:
	public bool isButton1 = false;
	bool doButton1 = false;
	public bool isButton2 = false;
	bool doButton2 = false;
	public bool isButton3 = false;
	bool doButton3 = false;

//move direction:
	public bool moveDown = true;
	public bool moveUp = false;
	public bool moveRight = false;
	public bool moveLeft = false;


//timing
	float timer = 0;
	float button1Timer = 0.5f;
	float button2Timer = 0.75f;
	float button3Timer = 1f;

//position
	float preOffsetPos;
	float startOffset = 100f;
	Vector3 startButtonPos;


	void Start(){
		startButtonPos = transform.position;
		
		if (moveDown == true){
			preOffsetPos = transform.position.y; //save the destination
			startButtonPos.y += startOffset;
			}
		else if (moveUp == true){
			preOffsetPos = transform.position.y; //save the destination
			startButtonPos.y -= startOffset;
			}
		else if (moveRight == true){
			preOffsetPos = transform.position.x; //save the destination
			startButtonPos.x -= startOffset;
		}
		else if (moveLeft == true){
			preOffsetPos = transform.position.x; //save the destination
			startButtonPos.x += startOffset;
		}
		transform.position = startButtonPos; //set the start position

		thisImage = GetComponent<Image>();
		thisImage.color = new Color(2.55f, 2.55f, 2.55f, 0f);
		buttonText = GetComponentInChildren<TextMeshProUGUI>();
		//buttonText = GetComponentInChildren<Text>(); 
		buttonText.color = new Color(2.55f, 2.55f, 2.55f, 0f);
	}

	void FixedUpdate () {
		timer += Time.deltaTime;
		if (timer >= button1Timer){doButton1=true;}
		if (timer >= button2Timer){doButton2=true;}
		if (timer >= button3Timer){doButton3=true;}

		if (
			((isButton1) && (doButton1))
			|| ((isButton2) && (doButton2))
			|| ((isButton3) && (doButton3))
		){
			// Tween Move:
			if((moveDown)&&(startButtonPos.y >= preOffsetPos)){
				startButtonPos.y -= curveMove.Evaluate(elapsedMove) * startOffset;
				transform.position = startButtonPos;
			}

			if((moveUp)&&(startButtonPos.y <= preOffsetPos)){
				startButtonPos.y += curveMove.Evaluate(elapsedMove) * startOffset;
				transform.position = startButtonPos;
			}

			if((moveRight)&&(startButtonPos.x <= preOffsetPos)){
				startButtonPos.x += curveMove.Evaluate(elapsedMove) * startOffset;
				transform.position = startButtonPos;
			}

			if((moveLeft)&&(startButtonPos.x >= preOffsetPos)){
				startButtonPos.x -= curveMove.Evaluate(elapsedMove) * startOffset;
				transform.position = startButtonPos;
			}


			// Tween Alpha:
			if (elapsed <= 1f){
				float newAlpha = curveAlpha.Evaluate(elapsed);
				thisImage.color = new Color(2.55f, 2.55f, 2.55f, newAlpha);
				buttonText.color = new Color(2.55f, 2.55f, 2.55f, newAlpha);
			}
			elapsed += Time.deltaTime;
			elapsedMove += (Time.deltaTime / 10f);
		}
	}
}