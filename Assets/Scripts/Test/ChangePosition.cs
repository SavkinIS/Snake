using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangePosition : MonoBehaviour
{
    [SerializeField]
    float rangePos;


    public Transform[] points;

    [SerializeField] Text text;
    Touch touch;
    Vector2 touchStart;
    Vector2 touchEnd;



    string direction;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        { 
            touch = Input.GetTouch(0); 
            if (touch.phase == TouchPhase.Began) 
            { 
                touchStart = touch.position; 
            }
            else if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Ended)
            {
                touchEnd = touch.position;
                float x = touchEnd.x - touchStart.x;
                float y = touchEnd.y - touchStart.y; 
                if (Mathf.Abs(x) == 0 && Mathf.Abs(y) == 0) direction = "Tapped";
                else if (Mathf.Abs(x) > Mathf.Abs(y)) 
                {
                    text.text = (x / 200).ToString();
                    transform.position = new Vector3(rangePos * (x/200), transform.position.y, transform.position.z);
                } 
                
            } 
        }

        if(transform.position.x < -20) transform.position = new Vector3(-20, transform.position.y, transform.position.z);
        else if(transform.position.x > 20) transform.position = new Vector3(20, transform.position.y, transform.position.z);
        else if(transform.position.x < 15 && transform.position.x >-15) transform.position = new Vector3(0, transform.position.y, transform.position.z);


    }
}