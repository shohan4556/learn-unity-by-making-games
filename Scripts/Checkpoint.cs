using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
create an empty gameobject, add tag "CheckPoint", attach this script on that gameobject
attach a collider, on the tirgger of the collider and you are done.
*/

public class Checkpoint : MonoBehaviour {

    public bool activated = false;
    public static GameObject[] checkpointList;

    // Use this for initialization
    void Start () {
        checkpointList = GameObject.FindGameObjectsWithTag ("CheckPoint");
    }

    private void ActivateCheckPoint ( ) {
        // deactivate all the checkpoints
        foreach(GameObject cp in checkpointList) {
            cp.GetComponent<Checkpoint> ().activated = false;
        }
        // activate the current one 
        activated = true;
    }

    void OnTriggerEnter2D(Collider2D col ) {
        // if the player pass through the check point 
        if(col.tag == "Player") {
            ActivateCheckPoint ();
        }
    }
    
    public static Vector2 GetActiveCheckPointPosition ( ) {
        // if player dies without activating any checkpoint 
        Vector2 result = new Vector2 (-13.25f, 4.35f);

        if(checkpointList != null) {
            foreach(GameObject cp in checkpointList) {
                if (cp.GetComponent<Checkpoint> ().activated) {
                    result = cp.transform.position;
                    break;
                }
            }
        }
        return result;
    }
    
}
