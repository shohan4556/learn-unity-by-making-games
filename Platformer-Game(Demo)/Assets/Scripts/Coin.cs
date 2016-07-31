using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

    private LevelManager levelmanager;
    public int coinValue = 1;
	// Use this for initialization
	void Start () {
        levelmanager = FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D col){
        if(col.tag == "Player"){
            levelmanager.AddCoins(coinValue);
            gameObject.SetActive(false);
            //Destroy(gameObject);
        }    
    }

}
