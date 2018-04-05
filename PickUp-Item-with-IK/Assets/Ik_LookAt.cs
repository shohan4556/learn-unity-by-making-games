using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ik_LookAt : MonoBehaviour {

    public GameObject target;
    public float weight = 1f;

    public Animator anim;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();

	}


    public void OnAnimatorIK(int layerIndex) {
        anim.SetLookAtPosition(target.transform.position);
        anim.SetLookAtWeight(weight);
    }

}
