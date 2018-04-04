using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour {

	CharacterController characterController;
	Animator animator;
	public float walkSpeed = 2f;
	public float runSpeed = 6f;
	public float turnSmoothTime = 0.2f;
	float turnSmoothVelocity;

	public float speedSmoothTime = 0.2f;
	float speedSmoothVelocity;
	float currentSpeed;

	// Use this for initialization
	void Start () {
		characterController = GetComponent<CharacterController>();
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float hor = Input.GetAxis("Horizontal");
		float vert = Input.GetAxis("Vertical");
		
		Vector2 inputDir = new Vector3(hor, vert).normalized;

		/*
		angle of the character moving 
		------------------------------
		//  arctan refers to "arc tangent", or the radian measure of the arc on a circle corresponding to a given value of tangent.

		 theta = atan (y/x);
		 unity : 
		 	char forward dir (R) = 90 - theta;
			or  (R) = atan(x/y);
		 */
		 if(inputDir != Vector2.zero){
			 float targetRotation =  Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg; 
			 transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, turnSmoothTime);

		 	//transform.eulerAngles = Vector3.up * Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg; 
		 }

		bool running = Input.GetKey(KeyCode.LeftShift);
		
		float targetSpeed =((running) ? runSpeed : walkSpeed) * inputDir.magnitude;
		currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, speedSmoothTime);

		transform.Translate(transform.forward * currentSpeed * Time.deltaTime, Space.World);

		float aniSpeed = ((running) ? 1: 0.5f ) * inputDir.magnitude; // values same as the locomotion blend tree
		animator.SetFloat("speed", aniSpeed, speedSmoothTime, Time.deltaTime);
		

	}
}
