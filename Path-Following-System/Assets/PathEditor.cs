using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PathEditor : MonoBehaviour {

    public Color rayColor = Color.white;
    public List<Transform> pathsObject = new List<Transform>();
    Transform[] theArray;

	// Use this for initialization
	void Start () {
	
	}
	
    void OnDrawGizmos(){
        Gizmos.color = rayColor;
        theArray = GetComponentsInChildren<Transform>();
        pathsObject.Clear();


        foreach(Transform obj in theArray){
            pathsObject.Add(obj);
        }


        for(int i=0; i<pathsObject.Count; i++){
            Vector2 position = pathsObject[i].position;
            if(i>0){
                Vector2 previous = pathsObject[i - 1].position;
                Gizmos.DrawLine(previous, position);
                Gizmos.DrawWireSphere(position, 0.2f);
            }
        }

    } // end 

}
