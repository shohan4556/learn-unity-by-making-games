using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {

	public Camera cam;

	public float shakeAmount = 0.6f;
	public float decrease = 1f;

	private Transform initialPos;

	private static float shake;

	void Start ()
	{
		shake = 0f;

        initialPos = cam.transform;
	}

	void Update ()
	{
		if (shake > 0f)
		{
			cam.transform.position =  Random.insideUnitCircle * shakeAmount ;
            Vector3 tmp = cam.transform.position;
            cam.transform.position = new Vector3(tmp.x, tmp.y, -10f); // the bug was the Z position of camera

			shake -= Time.deltaTime * decrease;
        } else
		{
			shake = 0f;
			cam.transform.position = new Vector3(0,0,-10f);
		}
	}

	public static void Shake (float amount)
	{
		shake = amount;
       // Debug.Log("shake");
	}

}
