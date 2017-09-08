using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollower : MonoBehaviour {

	public PathEditor pathEditor;
	public float speed  = 2f;
	public float rotSpeed = 1.5f;
	public float reachDist = 0.1f;
	int currentWayPointID = 0;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float distance = Vector3.Distance(pathEditor.nodes[currentWayPointID].position, transform.position);
		//print(distance);
		// move obj
		transform.position = Vector3.MoveTowards(transform.position, pathEditor.nodes[currentWayPointID].position, Time.deltaTime * speed);

		if(distance<=reachDist){
			currentWayPointID++;
		}
		if(currentWayPointID>=pathEditor.nodes.Count){
			currentWayPointID = 0;
		}

		Vector3 dir = (pathEditor.nodes[currentWayPointID].position - transform.position).normalized;
		Quaternion lookRot = Quaternion.LookRotation(dir);
		Quaternion targetRot = Quaternion.Euler(0, lookRot.y, 0) * transform.rotation;
		//transform.rotation = lookRot;
		transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, Time.deltaTime*rotSpeed);
	//transform.rotation = Quaternion.Euler(0, rot.y, 0);

	}


	 Vector3 GetPoint (Vector3 p0, Vector3 p1, Vector3 p2, float t) {
		 // B(t) = (1-t)2P0 + 2(1-t)tP1 + t2P2 , 0 < t < 1
		t = Mathf.Clamp01(t);
		float oneMinusT = 1f - t;
		return
			oneMinusT * oneMinusT * p0 +
			2f * oneMinusT * t * p1 +
			t * t * p2;
	}


}
