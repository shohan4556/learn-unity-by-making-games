using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseLoader : MonoBehaviour {

	public string Name;
	public int ID;
	public int Score;

	public string[] allData;

	// Use this for initialization
	IEnumerator Start () {
		WWW itemsData = new WWW("http://localhost/Unity3D/insertData.php");
		yield return itemsData;
		string data = itemsData.text;
		Debug.Log(data);

		allData = data.Split(' ');
	}


}
