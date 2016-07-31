using UnityEngine;
using System.Collections;

public class CheckpointController : MonoBehaviour {

    public Sprite flagClose;
    public Sprite flagOpen;

    private SpriteRenderer spriteRender;
    public bool checkPointActive;
	// Use this for initialization
	void Start () {
        spriteRender = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D col){
        if(col.tag == "Player"){
            spriteRender.sprite = flagOpen;
            checkPointActive = true;
        }
    }

}
