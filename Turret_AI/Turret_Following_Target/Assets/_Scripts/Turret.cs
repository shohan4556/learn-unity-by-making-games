using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

	public Transform theTarget;
	public float rotSpeed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		Vector3 dir = theTarget.position - transform.position;

		Quaternion _lookRotatio = Quaternion.LookRotation(dir);
		Vector3 rotation = Quaternion.Lerp(transform.rotation, _lookRotatio, Time.deltaTime*rotSpeed).eulerAngles;

		transform.rotation = Quaternion.Euler(0, rotation.y, 0);
	}

}
