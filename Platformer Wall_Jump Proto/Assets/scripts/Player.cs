using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public LayerMask colliderToHit;
    public LayerMask wallLayer;
    Rigidbody2D playerBody;
    public float moveSpeed = 16f;
    float distToGround;
    playerState state;
    BoxCollider2D collider;
    float leftX;
    float rightX;
    float wallSlidingSpeed = -2f;
    int wallDirection = 1;

    //public Vector2 walljumpClimb;
    //public Vector2 wallJumpOff;
    //public Vector2 wallLeap;

	// Use this for initialization
	void Start () {
        playerBody = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();

        // player pivot point to end of box size
        distToGround = collider.bounds.extents.y;
        rightX = collider.bounds.extents.x;
        leftX = -rightX;

        state.grouneded = false;
        state.onair = false;
        state.moveLeft = false;
        state.moveRight = false;
        state.touchingwall = false;
        state.wallJump = false;
        state.leftWall = false;
        state.rightWall = false;
	}

    private struct playerState {
        public bool grouneded,
            onair, 
            moveLeft,
            moveRight,
            touchingwall,
            wallJump,
            leftWall,
            rightWall,
            slidingWall;
    }

    void FixedUpdate() {
        movePlayer();
    }

    bool isGrounded() {
        return Physics2D.Raycast(transform.position, -Vector2.up, distToGround + 0.1f, colliderToHit);
    }

   bool isLeftWall() {
        return Physics2D.Raycast(transform.position, Vector2.right, leftX -0.1f, wallLayer);
    }

    bool isRightWall() {
        return Physics2D.Raycast(transform.position, Vector2.right, rightX + 0.1f, wallLayer);
    }

    void movePlayer() {

        state.grouneded = isGrounded();
        state.leftWall = isLeftWall();
        state.rightWall = isRightWall();

        if (state.rightWall) {
            wallDirection = 1;
        }
        else {
            wallDirection = -1;
        }

        if (state.leftWall == true || state.rightWall==true && state.grouneded == false && playerBody.velocity.y < 0) {
            state.slidingWall = true;
            if (playerBody.velocity.y < -wallSlidingSpeed) {
                playerBody.velocity = new Vector2(playerBody.velocity.x, wallSlidingSpeed);
            }
        }
        else {
            state.slidingWall = false;
        }


         drawRays();

        // jump 
        if (Input.GetButtonDown("Jump") ) {

            if (state.slidingWall) {
                if (Input.GetAxisRaw("Horizontal") == wallDirection) {
                    // climb
                    print("climb");
                    playerBody.velocity = new Vector2(-wallDirection * 5f, 7f);
                }
                else if (Input.GetAxisRaw("Horizontal") == 0) {
                    print("jump off  ");
                    playerBody.velocity = new Vector2(-wallDirection * 60f, 10f);
                }
                else {
                    // input opposite of wall direction 
                    print("wallleap");
                    // press the space and opposite movement key at once when sliding 
                    playerBody.velocity = new Vector2(-wallDirection * 30f, 12f);
                }
            }


            if (state.grouneded) {
                playerBody.velocity = new Vector2(0, 10f);
            }
        } // end 


        // movement player
        if (Input.GetAxisRaw("Horizontal") > 0) {
            state.moveRight = true;
            playerBody.velocity = new Vector2(moveSpeed , playerBody.velocity.y);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0) {
            state.moveLeft = true;
            playerBody.velocity = new Vector2(-moveSpeed , playerBody.velocity.y);
        }
        else {
            state.moveRight = false;
            state.moveLeft = false;
            playerBody.velocity = new Vector2(0, playerBody.velocity.y) ;
        }
    }

    void drawRays() {
        //  draw ray 
        Debug.DrawRay(transform.position, -Vector2.up, Color.green);
        Debug.DrawRay(transform.position, Vector2.right, Color.green);
        Debug.DrawRay(transform.position, -Vector2.right, Color.green);
    }
}
