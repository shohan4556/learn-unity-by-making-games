using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementRootMotion : MonoBehaviour {


    public bool blockPlayerRotation;
    public float desiredRotationSpeed;
    public float allowPlayerRotation;
    public bool isGrounded;
    public float verticalVel;
    public float jumpHeight = 1f;

    float speed;
    float inputX;
    float inputZ;
    float currentSpeed;
    Vector3 desiredMoveDir;
    Vector3 moveVector;
    CharacterController _charCont;
    Animator _animator;
    Camera _camera;
      

	// Use this for initialization
	void Start () {

        _animator = GetComponent<Animator>();
        _camera = Camera.main;
        _charCont = GetComponent<CharacterController>();

	}
	
	// Update is called once per frame
	void Update () {
        InputMagnitude();

        // gravity 
        isGrounded = _charCont.isGrounded;
        
        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space)) {
                _animator.SetTrigger("JumpTrigger");
                moveVector = new Vector3(0, 26f, 0);    
            }
                verticalVel = 0;
        }
        else
        {   // applying gravity 
            verticalVel -= 0.5f;
            moveVector = new Vector3(0, verticalVel, 0);
        }

        _charCont.Move(moveVector * Time.deltaTime);

	}

    void PlayerMoveAndRotation()
    {
        inputX = Input.GetAxis("Horizontal");
        inputZ = Input.GetAxis("Vertical");

        var camera = Camera.main;
        var forward = _camera.transform.forward;
        var right = _camera.transform.right;

        // dont need to move upword 
        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        //calculate rotation
        desiredMoveDir = (forward * inputZ) + (right * inputX);

        // player unable to rotate just move forward 
        if(blockPlayerRotation == false)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desiredMoveDir), desiredRotationSpeed);
        }

    } // end 


    void InputMagnitude()
    {
        // calculate the input vector 
        /*
            keys -> W, A, S, D 
        */
        inputX = Input.GetAxis("Horizontal");
        inputZ = Input.GetAxis("Vertical");

        _animator.SetFloat("InputX", inputX, 0.03f, Time.deltaTime);
        _animator.SetFloat("InputZ", inputZ, 0.03f, Time.deltaTime);

        // press left shift for running 
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        // calculate the input magnitude
        speed = new Vector2(inputX, inputZ).sqrMagnitude;
        float blendValue = ((isRunning) ? 1f : 0.5f) * speed;

        //if((_charCont.collisionFlags & CollisionFlags.Sides) != 0){
        //    Debug.Log("touching sides");
        // raycast or use normal vector 
        // }

       

        // move player 
        if (speed > allowPlayerRotation)
        {
            _animator.SetFloat("InputMagnitude", blendValue, 0.3f, Time.deltaTime);
            PlayerMoveAndRotation();
        }
        else if(speed < allowPlayerRotation)
        {
            _animator.SetFloat("InputMagnitude", blendValue, 0.3f, Time.deltaTime);
        }
    }

    void Jump() {

        
    } // end 

}
