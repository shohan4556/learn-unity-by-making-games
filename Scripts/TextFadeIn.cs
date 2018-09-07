using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TextFadeIn : MonoBehaviour {
    public Text textObj;
    public float waitBeforeStart = 2f;
    public float duration = 2f;

    // Use this for initialization
    private void Start(){
        textObj.color = new Color(255, 255, 255, 0);

        StartCoroutine(FadeTextCoroutine(waitBeforeStart));
    }

    private IEnumerator FadeTextCoroutine(float wait){
        yield return new WaitForSeconds(wait);

        while (textObj.color.a < 1.0f) {
            //print(textObj.color);
            textObj.color = new Color(textObj.color.r, textObj.color.g, textObj.color.b,
                textObj.color.a + Time.deltaTime / duration);
            yield return null;
        }
    }
}