using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JSONDemo : MonoBehaviour {

string path;
 string jsonString;
	/*
	If you have a "StreamingAssets" folder in the Assets folder of your project, it will be copied to your
	 player builds and be present in the path given by Application.streamingAssetsPath.
	 */

	void Start(){
		path = Application.streamingAssetsPath+"/questions.json";
		jsonString = File.ReadAllText(path);
		//print(jsonString);


//	 Q1 question = JsonUtility.FromJson<Q1>(jsonString);
	
//	 Debug.Log(question.Question_01.Ques);
	 
//	 Q2 q2 = JsonUtility.FromJson<Q2>(jsonString);
	 
//	 Debug.Log(q2.Question_02.Ques);

	} // end 

}


// create another class to parse json data 
/*
-- Serialization allows the developer to save the state of an object and recreate/restore it as needed, providing storage of objects as well as data exchange.
-- Serialization is the process of converting an object into a stream of bytes in order to store the object or transmit it to memory, a database, or a file.
 */

[System.Serializable]
public class Question 
{
	public string Ques;
	public string op1;
	public string op2;
	public string op3;
	public string op4;
	public string Answer;
}


[System.Serializable]
public class Q1
{
	public Question Question_01;
}


[System.Serializable]
public class Q2 
{
	public Question Question_02;
}
