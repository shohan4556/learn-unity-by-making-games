using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent (typeof(Rigidbody2D)) ]	
[RequireComponent (typeof(BoxCollider2D)) ]
public class PlayerController : MonoBehaviour {

	public struct playerState{
		public bool grounded, moveLeft, moveRight, onAir, swing;
	}

	public float movementSpeed = 5f;
	public float jumpForce = 5f;
	public float fallMultiplier = 2.5f;
	public float lowJumpMultiplier = 2f;
	public float distanceToGround = 0.2f;
	public LayerMask staticCollider;
	public playerState state;

	private Rigidbody2D rBody;

	// Use this for initialization
	void Awake () {
		rBody = GetComponent<Rigidbody2D>();

		state.grounded = false;
		state.moveLeft = false;
		state.moveRight = false;
		state.onAir = false;
		state.swing = false;
	}
	
	// Update is called once per frame
	void Update () {
		state.grounded = isGrounded();
		//print(state.grounded);
		BetterJump();
	}

	bool isGrounded(){
		return Physics2D.Raycast(transform.position, -Vector2.up, distanceToGround, staticCollider);
	}

	public void JUMP(){
		if(state.grounded){
			rBody.velocity = Vector2.up * jumpForce;
		}
	}

	public void MOVE_LEFT(){
		//print("moveLeft");
		rBody.velocity = new Vector2(-1*movementSpeed*Time.fixedDeltaTime, rBody.velocity.y);
	}

	public void MOVE_RIGHT(){
	//	print("moveRight");
		rBody.velocity = new Vector2(1*movementSpeed*Time.fixedDeltaTime, rBody.velocity.y);
	}

	public void STOP_MOVE(){
		rBody.velocity = new Vector2(0,rBody.velocity.y);
	}
	void BetterJump(){
		if(rBody.velocity.y<0){   // falling down 
			rBody.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier-1)*Time.fixedDeltaTime;
		}else if(rBody.velocity.y>0 && !Input.GetButton("Jump") ){
			rBody.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier-1)*Time.fixedDeltaTime;
		}
	}

} // end 
