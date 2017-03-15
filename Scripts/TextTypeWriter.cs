using UnityEngine;
using UnityEngine.UI;

// this script will allow you to create type writer effect of text just add some sound effects and you will see magic.

public class TextTypeWriter: MonoBehaviour {

	public float delay = 0.1f;
	public string fullText;
	private  string currentText;
	private Text theText;

	// Use this for initialization
	void Start () {
		theText = GetComponent<Text>();
	}
	
	IEnumerator typeWriteText(string text){
  
		for(int i=0;i <text.Length; i++){
			currentText = fullText.Substring(0,i);
			theText.text = currentText;
			yield return new WaitForSeconds(delay);
		}
    
	}

	public void startDialogue(){
		StartCoroutine(typeWriteText(fullText));
	}

}
