using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IK_Bot : MonoBehaviour {

    public GameObject target;
    public float weight = 1f;

    public Animator anim;

    // Use this for initialization
    void Start () {
		
	}

    public void OnAnimatorIK(int layerIndex) {
        anim.SetIKPosition(AvatarIKGoal.RightHand, target.transform.position);
        anim.SetIKPositionWeight(AvatarIKGoal.RightHand, weight); // weight range 0 - 1 (body part influence)
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            target.transform.Translate(0, 0.1f, 0);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            target.transform.Translate(0, -0.1f, 0);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            target.transform.Translate(0.1f, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            target.transform.Translate(-0.1f, 0, 0);
        }
    }
}
