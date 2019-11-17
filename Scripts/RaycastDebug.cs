using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastDebug : MonoBehaviour {
    private Vector3 _forwar;
    private Vector3 _backward;
    private Vector3 _left;
    private Vector3 _right;
    private float rayLength = 2f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        _forwar = transform.forward;
        _backward = -transform.forward;
        _right = transform.right;
        _left = -transform.right;
    }

    private void OnDrawGizmosSelected() {
        Debug.DrawRay(this.transform.position, _forwar * rayLength, Color.blue);
        Debug.DrawRay(this.transform.position, _backward * rayLength);
        Debug.DrawRay(this.transform.position, _left * rayLength);
        Debug.DrawRay(this.transform.position, _right * rayLength);
    }
}
