using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonBase<T> : MonoBehaviour where T : MonoBehaviour {

 
    private static object slock = new object(); // for thread safety 
    private static T sInstance; // tmp variable 

    public static T Instance
    {
        get {
            lock (slock) {
                if(sInstance == null) {
                    sInstance = GameObject.FindObjectOfType<T>(); 
                    if(sInstance == null) {
                        UnityEngine.Debug.LogError("Expected to find an instance of the " + typeof(T) + " component in the hierarchy but none found!\n"
                                     + "Attach the " + typeof(T) + " component to a GameObject in the hierarchy.");

                        Abort();
                    }
                    // got the instance
                    DontDestroyOnLoad(sInstance.transform.gameObject);
                }
                return sInstance;
            }
        }
    }

    private static void Abort() {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    private void Awake() {
        if(Instance != this) {
            Destroy(this.gameObject);
            return;
        }
    }

}
