using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject Target;
    public float followAhead = 3f;
    private Vector3 targetPosition;
    public float smooth = 3f;
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        // camera follow x & y axis
        targetPosition = new Vector3(Target.transform.position.x,this.transform.position.y, this.transform.position.z);
        // right 
        if(Target.transform.localScale.x > 0f){
            targetPosition = new Vector3(targetPosition.x + followAhead,targetPosition.y,targetPosition.z);
        } // left
        else if(Target.transform.localScale.x < 0f){
            targetPosition = new Vector3(targetPosition.x - followAhead, targetPosition.y, targetPosition.z);
        }
        // assign to camera's position
        //this.transform.position = targetPosition;

        // interpolation to smooth camera movement
        this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, Time.deltaTime * smooth);
	}
}
