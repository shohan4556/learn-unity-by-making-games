using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	static MusicPlayer instance = null;
	// Use this for initialization
	void Start () {
		if(instance!=null){
			Destroy (gameObject);
			print ("duplicate music is destroyed");
		}
		else{
			instance = this;
			GameObject.DontDestroyOnLoad (gameObject); // dont destroy when load another scene
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
