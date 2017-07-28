using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour {

    public GameObject LoadingScreen; // an UI image - deactive in hierarchy 
    public Slider loadingBar; // create a slider prefab


    // Use this for initialization
    void Start () {
     // if loadingBar and loadingScreen is active in hierarchy deactive
    }

	// laod scene 
    public void LoadScene ( int sceneID ) {
        StartCoroutine (LoadAsync (sceneID));

    }

    IEnumerator LoadAsync ( int sceneID ) {
        AsyncOperation operation = SceneManager.LoadSceneAsync (sceneID);

        LoadingScreen.SetActive (true);


        while (!operation.isDone) {
            float progress = Mathf.Clamp01 (operation.progress / 0.9f);

            loadingBar.value = progress;
            yield return null;
        }

    }


	// quite game 
    public void QuiteGame ( ) {
        Application.Quit ();
    }


}
