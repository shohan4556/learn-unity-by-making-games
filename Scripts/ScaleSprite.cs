using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleSprite : MonoBehaviour
{
    public float multiplier = 2f;
    private float cameraHeight;
    private float cameraWidth;
    
    
    // Start is called before the first frame update
    void Start()
    {
        cameraHeight = Camera.main.orthographicSize;
        cameraWidth = cameraHeight * Screen.width / Screen.height; // cameraHeight * aspect ratio
        
    }

    private void Update() {
        gameObject.transform.localScale = Vector3.one * cameraWidth / multiplier;
    }
}
