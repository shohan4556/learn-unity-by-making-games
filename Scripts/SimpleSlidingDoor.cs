using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum DoorState{
	Open,Animating, Closed
};

public class SimpleSlidingDoor: MonoBehaviour {

	public float slidingDistance = 5f; // calculate the distance 
	public float duration = 2f; // sliding time
	public AnimationCurve animationCurve;
	private Vector3 openPos = Vector3.zero;
	private Vector3 closedPos = Vector3.zero;
	private DoorState doorState  = DoorState.Closed;


	// Use this for initialization
	void Start () {
		closedPos = transform.position;
		openPos = closedPos + (transform.right * slidingDistance);
	}
	

	IEnumerator animateDoor( DoorState newState){
		doorState = DoorState.Animating;
		float time = 0;
		
		Vector3 startPos = (newState == DoorState.Open) ? closedPos : openPos;
		Vector3 endPos = (newState == DoorState.Open) ? openPos: closedPos;

			while(time<duration){
				float t = time/duration;
				transform.position = Vector3.Lerp(startPos, endPos, animationCurve.Evaluate(t));
				time += Time.deltaTime;
				yield return null;
			}

			transform.position = endPos;
			doorState = newState;
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space) && doorState != DoorState.Animating ){
			StartCoroutine(animateDoor( (doorState==DoorState.Open) ? DoorState.Closed:DoorState.Open ));
		}	
	}


}