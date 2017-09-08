using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableObj : MonoBehaviour {

	GameObject objToDrag = null;
	Vector3 lastMousePosition;
	Vector3 deltaMousePosition;
	public float mouseSensitivity = 10f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

// click on object initiate drag 
	if(Input.GetMouseButtonDown(0)){

		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // resulting ray in world space 
		RaycastHit hit;
		
		if(Physics.Raycast(ray, out hit)){
			if(hit.collider.tag == "Player"){
				objToDrag = hit.collider.gameObject;
				lastMousePosition = Input.mousePosition;
			}
		}
	}

// dragging 
	if(objToDrag !=null && Input.GetMouseButton(0)){
		deltaMousePosition = Input.mousePosition - lastMousePosition;
		
		Vector3 posToMove =  new Vector3(  deltaMousePosition.x, deltaMousePosition.z, deltaMousePosition.y );
		objToDrag.transform.position += (posToMove/mouseSensitivity);

		lastMousePosition = Input.mousePosition;
	}

	// release button 
	if(objToDrag!=null && Input.GetMouseButtonUp(0)){
		objToDrag = null;
	}


	} // end 


}
