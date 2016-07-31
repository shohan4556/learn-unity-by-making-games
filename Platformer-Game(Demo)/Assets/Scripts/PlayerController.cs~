using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    // github test

	private float movespeed = 150f;
    public float jumpSpeed = 100f;
	private Rigidbody2D playerBody;

    public Transform groundCheck;
    public float groundRadius;
    public LayerMask whatIsGround;
    public bool isGround = false;

    private Animator playerAnim;

    public Vector3 respawnPosition;

    public LevelManager theLevelManager;
    // kill enemy
    public GameObject stompbox;

    public float knockbackForce;
    public float knockbackLength;
    private float knockbackCounter;

    // sound
    public AudioSource jumpSound;
    public AudioSource hurtSound;

	// Use this for initialization
	void Start (){
        playerBody = GetComponent <Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
        // at the beginning of the game
        respawnPosition = transform.position;
        // get LevelManager script
        theLevelManager = FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
    void FixedUpdate (){
        // Check if a collider falls within a circular area.
        //The circle is defined by its centre coordinate in world space and by its radius. 
        //The optional layerMask allows the test to check only for objects on specific layers.

        isGround = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

        if (knockbackCounter <= 0)
        {
            //print(isGround);
            //move player 
            if (Input.GetAxisRaw("Horizontal") > 0f)
            {
                this.transform.localScale = new Vector3(1f, 1f, 1f);
                playerBody.velocity = new Vector3(movespeed * Time.deltaTime, playerBody.velocity.y, 0f);
            }
            else if (Input.GetAxisRaw("Horizontal") < 0f)
            {
                this.transform.localScale = new Vector3(-1f, 1f, 1f);
                playerBody.velocity = new Vector3(-movespeed * Time.deltaTime, playerBody.velocity.y, 0f);
            }
            else
            {
                playerBody.velocity = new Vector3(0, playerBody.velocity.y, 0);
            }
            // jump
            if (Input.GetButton("Jump") && isGround)
            {
                playerBody.velocity = new Vector3(playerBody.velocity.x, jumpSpeed * Time.deltaTime, 0);
                jumpSound.Play();
            }
        }

        // knockbackplayer when hurt by enemy
        if(knockbackCounter > 0){
            knockbackCounter -= Time.deltaTime;

            if(transform.localScale.x>0)
                 playerBody.velocity = new Vector3(-knockbackForce, 2f, 0f);
            else
                playerBody.velocity = new Vector3(knockbackForce, 2f, 0f);
        }

        // Animations
        playerAnim.SetFloat("Speed",Mathf.Abs(playerBody.velocity.x));
        playerAnim.SetBool("Grounded",isGround);


        if (playerBody.velocity.y < 0) // player moving down
        {
            stompbox.SetActive(true);   
        }
        else{
            stompbox.SetActive(false); // player moving up or on the ground
        }
        //Debug.Log(playerBody.velocity.y);

	}


    public void knockbackPlayer(){
        knockbackCounter = knockbackLength;
    }
        
    void OnTriggerEnter2D(Collider2D col){
        if(col.tag == "KillPlane"){
            theLevelManager.Respawn();
            //transform.position = respawnPosition;
        }

        if(col.tag == "Checkpoint"){
            respawnPosition = col.transform.position;
        }
    }

    // collide with moving platform
    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag == "MovingPlatform"){
            transform.parent = col.transform;
        }
    }

    void OnCollisionExit2D(Collision2D col){
        if(col.gameObject.tag == "MovingPlatform"){
            transform.parent = null;
        }
    }

}
