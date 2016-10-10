using UnityEngine;
using System.Collections;

public class pathFollower : MonoBehaviour {

    public PathEditor pathtofollow;

    public int currentWayPointID = 0;
    public float speed;
    private float reachDistance = 0.1f;
    public float rotationSpeed;
    public string pathName;

    Vector2 last_pos;
    Vector2 current_pos;

	// Use this for initialization
	void Start () {
        pathtofollow = GameObject.Find(pathName).GetComponent<PathEditor>();
        last_pos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        float distance = Vector2.Distance(pathtofollow.pathsObject[currentWayPointID].position, transform.position);
        transform.position = Vector2.MoveTowards(transform.position, pathtofollow.pathsObject[currentWayPointID].position, Time.fixedDeltaTime * speed);

        /*  Vector2 targetRotation = pathtofollow.pathsObject[currentWayPointID].position - transform.position;
        float angle = Mathf.Atan2(targetRotation.y, targetRotation.x) * Mathf.Rad2Deg;


        //var rotation = Quaternion.LookRotation(pathtofollow.pathsObject[currentWayPointID].position - transform.position);
        transform.rotation = Quaternion.Euler(transform.rotation.x, 0f, angle);*/


        if(distance <= reachDistance){
            currentWayPointID++;
        }

        if(currentWayPointID >= pathtofollow.pathsObject.Count){
            currentWayPointID = pathtofollow.pathsObject.Count-1;
        }

	}
}
