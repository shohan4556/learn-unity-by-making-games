using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class CarController2D : MonoBehaviour {

	public float speed = 1500f;
	public float rotationSpeed = 15f;
	private float movement = 0;
	private float rotation;
	public WheelJoint2D backWheel;
	public WheelJoint2D frontWheel;
	public Rigidbody2D rBody;
	void Update(){
		movement = Input.GetAxis("Vertical") * speed;
		rotation = Input.GetAxis("Horizontal");
		rBody =GetComponent<Rigidbody2D>();
	}


	void FixedUpdate()
	{
		if(movement == 0f){
			backWheel.useMotor = false;
			frontWheel.useMotor = false;
		}
		else{
			backWheel.useMotor = true;
			frontWheel.useMotor = true;

			JointMotor2D motor = new JointMotor2D { motorSpeed = movement, maxMotorTorque = backWheel.motor.maxMotorTorque };
			backWheel.motor = motor;
			frontWheel.motor = motor;
		}

		rBody.AddTorque(-rotation*rotationSpeed*Time.fixedDeltaTime);

	}

}
