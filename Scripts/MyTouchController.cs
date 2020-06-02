using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MyTouchController : MonoBehaviour
{
    //public Text debug;
    private Vector2 _touchEndPos;
    private Vector2 _touchStartPos;
    // todo add time threshold on swipe 
    private float _startTime;
    private float _endTime;
    
    public bool detectSwipeOnlyAfterRelease = false;
    public float SWIPE_THRESHOLD = 20f;
    public float TIME_THRESHOLD = 0.3f;
    
    [Space(15)] 
    public UnityEvent OnLeftUpSwipe;
    public UnityEvent OnRightUpSwipe;
    public UnityEvent OnRightSwipe;
        
    private void Start() {

    }

    private void Update()
    {

#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0)) {
            //print("tap");
            this._touchStartPos = Input.mousePosition;
            //this.touchEndPos = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0)) {
            this._touchEndPos = Input.mousePosition;
            this.CheckSwipe();
        }
#endif

        if (Input.touchCount > 0)
        {
            // get touch 
            Touch touch = Input.GetTouch(0);
            
            // if started swipe 
            if (touch.phase == TouchPhase.Began) {
                // get start position 
                _touchStartPos = touch.position;
                //touchEndPos = touch.position;
            }

            if (touch.phase == TouchPhase.Moved) {
                if (!detectSwipeOnlyAfterRelease) {
                    _touchEndPos = touch.position;
                    CheckSwipe();
                }
            }
            
            if (touch.phase == TouchPhase.Ended) {
                _touchEndPos = touch.position;
                CheckSwipe();
            }
        }
    }

    void CheckSwipe() {
        
        //check vertical swipe 
        if (VerticalMove() > SWIPE_THRESHOLD && VerticalMove() > HorizontalMove()) {
            // check direction of the swipe
            
            if ((_touchEndPos.y - _touchStartPos.y > 0f) && _touchStartPos.x < (Screen.width / 2)) {
                OnLeftUpSwipe.Invoke();
                //debug.text = "LEFT UP";
            }
            else if ((_touchEndPos.y - _touchStartPos.y > 0f) && _touchStartPos.x > (Screen.width / 2)) {
                OnRightUpSwipe.Invoke();
                //debug.text = "RIGHT UP";
            }
            else if (_touchEndPos.y - _touchStartPos.y < 0f) {
                //debug.text = " DOWN";
            } 
            _touchStartPos = _touchEndPos;
        }
        else if (HorizontalMove() > SWIPE_THRESHOLD && HorizontalMove() > VerticalMove()) {
            if (_touchEndPos.x - _touchStartPos.x > 0) {
                //debug.text = "RIGHT";
                OnRightSwipe.Invoke();
            }

            _touchStartPos = _touchEndPos;
        }
    }

    float VerticalMove() {
        return Mathf.Abs(_touchEndPos.y - _touchStartPos.y);
    }

    float HorizontalMove() {
        return Mathf.Abs(_touchEndPos.x - _touchStartPos.x);
    }

}