using UnityEngine;
using System.Collections;

public class moving_enemy : MonoBehaviour {

    public Transform leftPoint;
    public Transform rightPoint;
    public float moveSpeed;
    public bool moveRight;

    private Rigidbody2D myrigidbody;

	// Use this for initialization
	void Start () {
        myrigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        
        if(moveRight && transform.position.x > rightPoint.position.x ){
            moveRight = false; // too far from right point now move left
        }

        if(!moveRight && transform.position.x < leftPoint.position.x){
            moveRight = true; // too far from left point now move right
        }

        if(moveRight){
            transform.localScale = new Vector3(-1, 1, 1);
            myrigidbody.velocity = new Vector3(moveSpeed,myrigidbody.velocity.y,0f);
        }
        else{
            transform.localScale = new Vector3(1, 1, 1);
            myrigidbody.velocity = new Vector3(-moveSpeed, myrigidbody.velocity.y, 0f);
        }

	}
}




