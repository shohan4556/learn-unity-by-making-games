using UnityEngine;
using System.Collections;

public class PathFollower : MonoBehaviour {


    public Transform[] paths;
    public float moveSpeed;
    public float reachDistance = 1f;
    public int currentPoint;
 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
        //Vector3 dir = paths[currentPoint].position - transform.position;

        float distance = Vector3.Distance(paths[currentPoint].position, transform.position);

        Debug.Log("distance : "+distance);

        // or use MoveTowards()
        transform.position = Vector3.Lerp(transform.position, paths[currentPoint].position,Time.deltaTime * moveSpeed);

        //print("vector "+dir);
        //print(dir.magnitude);
        if(distance <= reachDistance){
            currentPoint++;
            // print(dir.magnitude);
        }

        if(currentPoint >= paths.Length ){
            currentPoint = 0;
        }
	}


    void OnDrawGizmos(){
       
        //print("draw gizmos");

        if (paths.Length > 0)
        {
            for (int i = 0; i < paths.Length; i++)
            {
                if (paths[i] != null)
                {
                    Gizmos.DrawSphere(paths[i].position, reachDistance);        
                }    
            }
        }

    }

    
}














