using System.Collections;
using System.IO;
using UnityEngine;

public class NativeShareScript : MonoBehaviour {
    public GameObject CanvasShareObj;

    private bool isProcessing;
    private bool isFocus;

    public void ShareBtnPress(){
        if (!isProcessing) {
            CanvasShareObj.SetActive(true);
            StartCoroutine(ShareScreenshot());
        }
    }

    private IEnumerator ShareScreenshot(){
        isProcessing = true;

        yield return new WaitForEndOfFrame();

        ScreenCapture.CaptureScreenshot("screenshot.png", 2);
        var destination = Path.Combine(Application.persistentDataPath, "screenshot.png");

        yield return new WaitForSecondsRealtime(0.3f);

        if (!Application.isEditor) {
            var intentClass = new AndroidJavaClass("android.content.Intent");
            var intentObject = new AndroidJavaObject("android.content.Intent");
            intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_SEND"));
            var uriClass = new AndroidJavaClass("android.net.Uri");
            var uriObject = uriClass.CallStatic<AndroidJavaObject>("parse", "file://" + destination);
            intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_STREAM"),
                uriObject);
            intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"),
                "Can you beat my score?");
            intentObject.Call<AndroidJavaObject>("setType", "image/jpeg");
            var unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            var currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");
            var chooser = intentClass.CallStatic<AndroidJavaObject>("createChooser", intentObject, "Share your new score");
            currentActivity.Call("startActivity", chooser);

            yield return new WaitForSecondsRealtime(1);
        }

        yield return new WaitUntil(() => isFocus);
        CanvasShareObj.SetActive(false);
        isProcessing = false;
    }

    private void OnApplicationFocus(bool focus){
        isFocus = focus;
    }
}