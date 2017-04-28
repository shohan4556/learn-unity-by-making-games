using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camearaFollower : MonoBehaviour {

	public Transform target;

	 /// <summary>
	/// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
	/// </summary>
	void FixedUpdate()
	{
		Vector3 pos = target.position;
		pos.z = -10f;
		transform.position = pos;
	}
}
