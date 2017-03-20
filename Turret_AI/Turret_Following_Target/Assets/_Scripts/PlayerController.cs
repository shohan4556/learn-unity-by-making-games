using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float h = Input.GetAxis("Horizontal")*Time.deltaTime*5f;
		float v = Input.GetAxis("Vertical")*Time.deltaTime*5f;

		transform.Translate(new Vector3(h,0,v));
	}
}
