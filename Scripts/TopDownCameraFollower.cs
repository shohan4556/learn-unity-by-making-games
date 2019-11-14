using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCameraFollower : MonoBehaviour {

    public Transform target;
    public float distance = 10f;
    public float height = 10f;
    public float angle = 45f;
    public float smoothStep = 0.5f;
    private Vector3 velocity;

    // Use this for initialization
    void Start () {
        HandleCamera();
    }
    
    // Update is called once per frame
    void Update () {

       if(target == null)
           return;
       
       HandleCamera();
       
    }

    public void HandleCamera() {
        Vector3 worldPos = (Vector3.forward * -distance) + (Vector3.up * height); 
        Vector3 targetRot = Quaternion.AngleAxis(angle, Vector3.up) * worldPos;

        Vector3 targetPos = target.position;
        targetPos.y = 0f;
        Vector3 finalPos = targetPos + targetRot;
        transform.position = Vector3.SmoothDamp(transform.position, finalPos, ref velocity, smoothStep);
        transform.LookAt(targetPos);
    }

    private void OnDrawGizmos() {
        if (target != null) {
            Gizmos.DrawLine(transform.position, target.position);
            Gizmos.DrawSphere(transform.position,1.5f);
            
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(target.position, 1f);
        }
    }
}
