using UnityEngine;
using System.Collections;

public class HurtPlayer : MonoBehaviour {

    private LevelManager thelevelManager;

    public int damageToGive;

	// Use this for initialization
	void Start () {
        thelevelManager = FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D col){
        if(col.tag == "Player"){
               thelevelManager.HurtPlayer(damageToGive);
              //thelevelManager.Respawn();
        }
    }

}
