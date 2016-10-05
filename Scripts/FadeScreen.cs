using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeScreen : MonoBehaviour {

    public Texture2D fadeTexture;

    [Range(0.1f,1f)]
    public float fadespeed;
    public int drawDepth = -1000;

    private float alpha = 0; // to fade out make it zero 0 
    private float fadeDir = -1f;

	// Use this for initialization
	void Start () {
	
	}
	

    void OnGUI() {

        alpha -= fadeDir * fadespeed * Time.deltaTime; // and it will be negative
        alpha = Mathf.Clamp01(alpha);

        Color newColor = GUI.color; 
        newColor.a = alpha;

        GUI.color = newColor;

        GUI.depth = drawDepth;

        GUI.DrawTexture( new Rect(0,0, Screen.width, Screen.height), fadeTexture);

    }

  

}
