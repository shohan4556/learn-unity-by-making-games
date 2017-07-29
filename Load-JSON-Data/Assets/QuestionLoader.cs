using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class QuestionLoader : MonoBehaviour {

	public Text questionText;
	public Text option1;
	public Text option2;
	public Text option3;
	public Text option4;

	string path;
	string jsonString;

	// Use this for initialization
	void Start () {


		path = Application.streamingAssetsPath+"/questions.json";
		jsonString = File.ReadAllText(path);


         Q1 question = JsonUtility.FromJson<Q1>(jsonString);
	
 		Debug.Log(question.Question_01.Ques);

		 // load data in game
		 questionText.text = question.Question_01.Ques;
		 option1.text = question.Question_01.op1;
		 option2.text = question.Question_01.op2;
		 option3.text = question.Question_01.op3;
		 option4.text = question.Question_01.op4;

	}
	
}
