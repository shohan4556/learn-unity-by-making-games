using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Level_Manager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	public void nextLevel(){
		int levelIndex = SceneManager.GetActiveScene ().buildIndex;
		levelIndex = levelIndex + 1;
		Bricks.breakableCount = 0;
		SceneManager.LoadScene (levelIndex);
		print (levelIndex);
	}

	public void BrickDestroyed(){
		if(Bricks.breakableCount<=0){
		nextLevel (); // when all the bricks are destroyed move on the next level
		}
	}
	public void PlayAgain(){
		SceneManager.LoadScene (0);
	}

	public void LossScreen(){
		SceneManager.LoadScene ("Lost");
	}

	// Update is called once per frame
	void Update () {
	
	}
}
