using UnityEngine;

public class TargetFPS : MonoBehaviour {
    public void Start(){
#if UNITY_ANDROID
        Application.targetFrameRate = 60;
#elif UNITY_EDITOR
        Application.targetFrameRate = 120;
#endif

        QualitySettings.vSyncCount = 0;
    }
}
