using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SimpleTimer : MonoBehaviour {

	
	public float Duration; // 45 secs 

	// Use this for initialization
	void Start () {
			StartCoroutine(Timer(Duration));
	}
	
	IEnumerator Timer(float duration){
			float start_time = Time.time;
			//float time = duration;
			//float value = 0;

			while(Time.time - start_time <duration){
				
				// if you need to change value of image fill amount depends on the time
				/*
				time -= Time.deltaTime;
				value = time / duration;
				timerImage.fillAmount = value;				
				*/
				Debug.Log(Mathf.FloorToInt(Time.time)+ "Second");
				yield return null;
			}
			
	}
	
}
