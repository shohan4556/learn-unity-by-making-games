using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour {

    public float lifeTime;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        lifeTime = lifeTime - Time.deltaTime;
        if(lifeTime<=0 && gameObject!=null){
            Debug.Log(gameObject.name);
            Destroy(gameObject);
            lifeTime = 5f;
        }
	}
}
