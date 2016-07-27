using UnityEngine;
using System.Collections;

public class Bricks : MonoBehaviour {
	
	public static int breakableCount = 0;
	private Level_Manager levelmanager;
	private bool isbreakable = false;
	// Use this for initialization
	void Start () {
		isbreakable = (this.tag == "Breakable");
		if(isbreakable){
			breakableCount++;
			print ("total brick counted : "+breakableCount);
		}
		levelmanager = GameObject.FindObjectOfType <Level_Manager> ();
	}
	
	// Update is called once per frame
	void OnCollisionExit2D(Collision2D col){
		if (isbreakable)
			handleHits ();
	}

	void handleHits(){
		breakableCount--;
		print ("destroyed : "+breakableCount);
		levelmanager.BrickDestroyed ();
		Destroy (gameObject);
	}
}

