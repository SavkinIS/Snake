using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeMove : MonoBehaviour {

    private Vector2 startTouchPosition, endTouchPosition;

    // Update is called once per frame
    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            startTouchPosition = Input.GetTouch(0).position;

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouchPosition = Input.GetTouch(0).position;

            if ((endTouchPosition.x < startTouchPosition.x) && transform.position.x > -5f)
                transform.position = new Vector3(transform.localPosition.x - 5f, transform.position.y, transform.position.z);

            if ((endTouchPosition.x > startTouchPosition.x) && transform.position.x < 5f)
                transform.position = new Vector3(transform.localPosition.x +5f, transform.position.y, transform.position.z);
        }
    }    
}
