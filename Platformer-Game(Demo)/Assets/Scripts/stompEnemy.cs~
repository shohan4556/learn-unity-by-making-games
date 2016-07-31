using UnityEngine;
using System.Collections;

public class stompEnemy : MonoBehaviour {

    public GameObject deathExplosion;

    private Rigidbody2D playerRigidbody;
    private float bounceForce = 5f;

    // Use this for initialization
	void Start () {
        playerRigidbody = transform.parent.GetComponent<Rigidbody2D>();   
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D col){
        if(col.tag == "Enemy"){
            //Destroy(col.gameObject);
            col.gameObject.SetActive(false);
            // instantiate death-explosion partical effect
            Instantiate(deathExplosion, col.transform.position,col.transform.rotation);
            playerRigidbody.velocity = new Vector3(playerRigidbody.velocity.x, bounceForce, 0f);
        }
    }


}
