using UnityEngine;
using System.Collections;

public class Behaviour : MonoBehaviour {


    void OnEnable(){
        
    }
        	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.up * Time.deltaTime * 10);

        if(transform.position.y > 20){
            gameObject.SetActive(false);
            //OnDisable();
        }

	}

    void OnDisable(){
        //Debug.Log("disabled");
       // gameObject.SetActive(false);
    }
}
