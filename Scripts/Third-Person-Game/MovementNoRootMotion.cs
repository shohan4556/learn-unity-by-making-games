using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementNoRootMotion : MonoBehaviour {

	CharacterController characterController;
	Animator animator;
	public float walkSpeed = 1f;
	public float runSpeed = 2f;
	public float turnSmoothTime = 0.2f;

    public float gravity = -9.8f;
	public float speedSmoothTime = 0.2f;

    float turnSmoothVelocity;
    float speedSmoothVelocity;
	float currentSpeed;
    float velocityY;
    public float jumpHeight = 10f;

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

        // jump
        if (Input.GetKeyDown(KeyCode.Space)) {
            Jump();
        }

		/*
		angle of the character moving 
		------------------------------
		//  arctan refers to "arc tangent", or the radian measure of the arc on a circle 
            corresponding to a given value of tangent.

		 theta = atan (y/x);
		 unity : 
		 	char forward dir (R) = 90 - theta;
			or  (R) = atan(x/y);
		 */
		 if(inputDir != Vector2.zero){
              // get the rotation from input vector 
			 float targetRotation =  Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg; 
			 transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, turnSmoothTime);

		 	//transform.eulerAngles = Vector3.up * Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg; 
		 }

		bool running = Input.GetKey(KeyCode.LeftShift);
		
		float targetSpeed =((running) ? runSpeed : walkSpeed) * inputDir.magnitude;
		currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, speedSmoothTime);

        velocityY += Time.deltaTime * gravity;
		Vector3 velocity = transform.forward * currentSpeed + Vector3.up * velocityY;
        // movement 
        characterController.Move(velocity * Time.deltaTime);

        // enable gravity 
        if (characterController.isGrounded) {
            velocityY = 0;
        }

        // blend value 
        float aniSpeed = ((running) ? 1: 0.5f ) * inputDir.magnitude; 
		animator.SetFloat("InputMagnitude", aniSpeed, speedSmoothTime, Time.deltaTime);
		

	}

    public void Jump() {
        if (characterController.isGrounded) {
            velocityY = Mathf.Sqrt(-2 * gravity * jumpHeight);
            animator.SetTrigger("JumpTrigger");
        }
    }

}
