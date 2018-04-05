using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IK_PickUp : MonoBehaviour {

    public Transform hand;
    Animator animator;
    [SerializeField]
    private float weight;

    public Transform target;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space)) {
            animator.SetTrigger("pickUp");
        }
	}

    private void OnAnimatorIK(int layerIndex) {
        weight = animator.GetFloat("IKPickUp");

        if(weight > 0.8) {
            target.SetParent(hand);
            target.transform.localPosition = Vector3.zero;
            target.localRotation = Quaternion.Euler(Vector3.zero);
        }

        animator.SetIKPosition(AvatarIKGoal.RightHand, target.position);
        animator.SetIKPositionWeight(AvatarIKGoal.RightHand, weight);
    }

}
