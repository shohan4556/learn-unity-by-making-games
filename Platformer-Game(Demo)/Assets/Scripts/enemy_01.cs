using UnityEngine;
using System.Collections;

public class enemy_01 : MonoBehaviour {

    public float moveSpeed;
    private bool flag;
    private Rigidbody2D myrigidbody;

	// Use this for initialization
	void Start () {
        myrigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        // enemy can move when player is on the screen 
        if(flag){
            myrigidbody.velocity = new Vector3(-moveSpeed, myrigidbody.velocity.y, 0f);
        }
	}

    // called when gameObject is visible on any camera
    void OnBecameVisible(){
        flag = true;
    }

    // destroy gameobject
    void OnTriggerEnter2D(Collider2D col){
        if(col.tag == "KillPlane"){
            gameObject.SetActive(false);
            // col.gameObject.SetActive(false);
            // Destroy(gameObject);
        }
    }

}
