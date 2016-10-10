using UnityEngine;
using System.Collections;

public class sineWave : MonoBehaviour {
    
    private Vector2 vLastPos;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        
        // sine wave 
        vLastPos = new Vector2(transform.position.x , Mathf.Sin(Time.time)*2f+2f);

        transform.position  = vLastPos+Vector2.left*Time.deltaTime;


	}

}
