using UnityEngine;
using System.Collections;

public class TouchController : MonoBehaviour {

    private PlayerController theplayer;
   

    private Vector2 offset;
    private Vector2 touchPos;

    bool isDragging = false;
    //private Vector2 offset;
    public float speed;
    private Touch  _touch;

    // Use this for initialization
	void Start () {
        theplayer = FindObjectOfType<PlayerController>();

	}
	
	// Update is called once per frame
	void Update () {

        if (Input.touchCount > 0)
        {
             _touch = Input.GetTouch(0); // screen has been touched, store the touch 

            if(_touch.phase == TouchPhase.Began){
                isDragging = true;

                offset = Camera.main.ScreenToWorldPoint(new Vector2(_touch.position.x, _touch.position.y)) - theplayer.transform.position;

            }
            else if(_touch.phase == TouchPhase.Ended){
                offset = Vector2.zero;
                isDragging = false;
            }

        }

        if(isDragging){
            Vector2 _dir = Camera.main.ScreenToWorldPoint(new Vector2(_touch.position.x, _touch.position.y));
            _dir = _dir - offset;

            // move playe with touch 
            movePlayer(_dir);
        }
            

	} // end 


    private void movePlayer(Vector2 _direction){
        // prevent go outside of screen
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)); // return the bottom-left position 
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)); // return the top-right position

        max.x = max.x - 0.5f; // subtract player sprite half 
        min.x = min.x + 0.5f;

        max.y = max.y - 0.5f;
        min.y = min.y + 0.5f;

        Vector2 newPos = Vector2.zero;

        newPos.x = Mathf.Clamp(_direction.x, min.x, max.x);
        newPos.y = Mathf.Clamp(_direction.y, min.y, max.y);

        theplayer.transform.position = Vector2.Lerp(theplayer.transform.position, newPos, Time.deltaTime * speed);

    }

}

/*

//another script work same as touch but with mouseInput 

	// Use this for initialization
	void Start () {
        player = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)) {
            offset = Camera.main.ScreenToWorldPoint(Input.mousePosition) - player.position;
            isDragging = true;

            // Released the touch screen
        } else if (Input.GetMouseButtonUp(0)) {
            offset = Vector2.zero;
            isDragging = false;
        }

        if (isDragging) {
            Vector2 destination = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - offset;
            player.position = Vector2.Lerp(player.position, destination, speed * Time.deltaTime);
        }
	}
*/
