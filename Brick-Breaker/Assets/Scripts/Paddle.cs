using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public bool autoPlay = false;
	private float maxX, minX;

	private Ball ball;
	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType <Ball> ();
		minX = 2.62f;
		maxX = 13.42f;
	}
	
	// Update is called once per frame
	void Update () {
		if(autoPlay == false){
			moveWithMouse ();
		}
		else{
			AutoPlay ();
		}
	}

	void moveWithMouse(){
		Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, 0f);
		float mousePosInBlock = Input.mousePosition.x / Screen.width * 16;
		paddlePos.x = Mathf.Clamp (mousePosInBlock, minX, maxX);
		this.transform.position = paddlePos;
	}

	void AutoPlay(){
		Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, 0f);
		Vector3 ballPos = ball.transform.position;
		paddlePos.x = Mathf.Clamp (ballPos.x, minX, maxX);
		this.transform.position = paddlePos;
	}
}




