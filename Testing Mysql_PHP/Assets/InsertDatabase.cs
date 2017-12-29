using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsertDatabase : MonoBehaviour {

	string url = "http://localhost/Unity3D/insertData.php";

	// Use this for initialization
	void Start () {
		
	}
	
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Space)){
			insert("shohan",003,5000);
		}	
	}

	public void insert(string name, int id, int score){
		WWWForm wwwfrom = new WWWForm();

		wwwfrom.AddField("idPost", id);
		wwwfrom.AddField("namePost", name);
		wwwfrom.AddField("scorePost", score);

		WWW www = new WWW(url, wwwfrom);
	}

}
