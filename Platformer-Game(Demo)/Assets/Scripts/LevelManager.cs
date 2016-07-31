using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public float waitToRespawn = 2f;
    private PlayerController thePlayer;
    public GameObject deathExplosion;

    public int coinCount;
    public Text coinText;

    // heart manager
    public Image heart1;
    public Image heart2;
    public Image heart3;

    public Sprite HeartFull;
    public Sprite HeartHalf;
    public Sprite HeartEmpty;

    public int maxHealth;
    public int HealthCount;

    private bool flag = false;
    private bool invincible = false;

    public ResetOnRespawn[] objectToReset;

    public AudioSource coinSound;

    private int startingLives = 3;
    public Text liveText;
    private int currentLives;

    public GameObject gameOverScreen;

	// Use this for initialization
	void Start () {
        thePlayer = FindObjectOfType<PlayerController>();
        HealthCount = maxHealth;
        coinText.text = "0000";

        //return an array of objects 
        objectToReset = FindObjectsOfType<ResetOnRespawn>();

        currentLives = startingLives;
        liveText.text = "Lives x " + currentLives.ToString();
   
	}
	
	// Update is called once per frame
	void Update () {
	    
        if(HealthCount<=0 && !flag){
            Respawn();
            flag = true;
        }
	}

    public void Respawn(){

        currentLives -= 1;
        liveText.text = "Lives x " + currentLives.ToString();

        if (currentLives > 0)
        {
            // starting coroutine here
            StartCoroutine("RespawnCo");
        }
        else{
            // gameover
            thePlayer.gameObject.SetActive(false);
            gameOverScreen.SetActive(true);
        }
    }

    // respawn coroutine
    public IEnumerator RespawnCo(){
        thePlayer.gameObject.SetActive(false);
        //Instantiate(deathExplosion);   
        Instantiate(deathExplosion, thePlayer.transform.position, thePlayer.transform.rotation);
        // wait for 2 seconds, then execute the remaining statement
        yield return new WaitForSeconds(waitToRespawn);

        HealthCount = maxHealth; // initialize health
        flag = false;
        updateHeart();
        coinCount = 0;
        coinText.text = coinCount.ToString();

        thePlayer.transform.position = thePlayer.respawnPosition;
        thePlayer.gameObject.SetActive(true);

        // respwan enemy objects
        for(int i=0;i<objectToReset.Length;i++){
            objectToReset[i].gameObject.SetActive(true);
            objectToReset[i].ResetObject();
        }

    }

    public void AddCoins(int cn){
        coinCount = coinCount + cn;
        coinText.text = coinCount.ToString();

        //play coin sound
        coinSound.Play();
    }

    public void HurtPlayer(int damage){
        HealthCount -= damage;

        // play hurtSound
        thePlayer.hurtSound.Play();
        thePlayer.knockbackPlayer();

        updateHeart();
    }

    public void updateHeart(){
        switch(HealthCount){
            case 6: 
                heart1.sprite = HeartFull;
                heart2.sprite = HeartFull;
                heart3.sprite = HeartFull;
                return;

            case 5: 
                heart1.sprite = HeartFull;
                heart2.sprite = HeartFull;
                heart3.sprite = HeartHalf;
                return;

            case 4:
                heart1.sprite = HeartFull;
                heart2.sprite = HeartFull;
                heart3.sprite = HeartEmpty;
                return;

            case 3:
                heart1.sprite = HeartFull;
                heart2.sprite = HeartHalf;
                heart3.sprite = HeartEmpty;
                return;
            
            case 2:
                heart1.sprite = HeartFull;
                heart2.sprite = HeartEmpty;
                heart3.sprite = HeartEmpty;
                return;

            case 1:
                heart1.sprite = HeartHalf;
                heart2.sprite = HeartEmpty;
                heart3.sprite = HeartEmpty;
                return;
        
            case 0:
                heart1.sprite = HeartEmpty;
                heart2.sprite = HeartEmpty;
                heart3.sprite = HeartEmpty;
                return;

                default :
                heart1.sprite = HeartEmpty;
                heart2.sprite = HeartEmpty;
                heart3.sprite = HeartEmpty;
                return;
                    
        }

    } // end method

}
