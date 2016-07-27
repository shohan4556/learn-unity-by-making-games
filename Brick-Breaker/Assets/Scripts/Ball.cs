using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	// Use this for initialization
	private Paddle paddle;
	private bool hasStarted = false;
	private Vector3 paddleToBallVector;

	void Start () {
		paddle = GameObject.FindObjectOfType <Paddle> ();
		paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if(!hasStarted){
			// lock the ball
			this.transform.position = paddleToBallVector + paddle.transform.position;
			if(Input.GetMouseButtonDown (0)){
				hasStarted = true;
				this.GetComponent <Rigidbody2D> ().velocity = new Vector2 (2f, 14f);
			}
		}
	} // end update

	void OncollissionEnter2D(Collision2D coll){
		Vector2 tweak = new Vector2 (Random.Range (0f,0.2f),Random.Range (0f,0.2f));
		if(hasStarted){
			this.GetComponent <Rigidbody2D>().velocity += tweak;
		}
	}

}



