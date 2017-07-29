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

		questions_parser myQuestion = JsonUtility.FromJson<questions_parser>(jsonString);
		
		Debug.Log(myQuestion.Question1);
		Debug.Log(myQuestion.Answer1);
	}

}


// create another class to parse json data 
/*
-- Serialization allows the developer to save the state of an object and recreate/restore it as needed, providing storage of objects as well as data exchange.
-- Serialization is the process of converting an object into a stream of bytes in order to store the object or transmit it to memory, a database, or a file.
 */

 [System.Serializable]
public class questions_parser
{
	public string Question1; // property name should same as json property
	public string Answer1;
}
