using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Author : Shohan 
smooth camera follower 
*/

public class CameraFollower : MonoBehaviour {


    public GameObject theTarget;
    private Vector3 offset;

    public float speed = 2f;

    // Use this for initialization
    void Start () {
        offset =  theTarget.transform.position - this.transform.position ;
    }
    
    // Update is called once per frame
    void Update () {

        if (theTarget != null) {

            offset = (theTarget.transform.position - this.transform.position);
            Vector3 destination = offset + transform.position;
            destination.z = -10f;
            // destination.Normalize ();
            float interpolation = speed * Time.deltaTime;

            transform.position = Vector3.Lerp(transform.position, destination, interpolation);

        }

    }


}
