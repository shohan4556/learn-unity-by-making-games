using UnityEngine;
using System.Collections;

public class LossCollider : MonoBehaviour {

	// Use this for initialization
	private Level_Manager levelmanager;

	void Start () {
	
	}

	void OnTriggerEnter2D(Collider2D col){
		levelmanager = GameObject.FindObjectOfType <Level_Manager> ();
		levelmanager.LossScreen ();
	}

	// Update is called once per frame
	void Update () {
	
	}
}
