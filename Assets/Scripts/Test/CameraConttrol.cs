using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraConttrol : MonoBehaviour
{
    float vectorX;
    Transform target;
    Vector3 startPos;
    void Start()
    {
        target = FindObjectOfType<MoveSnake>().transform;
        vectorX = transform.position.x;
        startPos = transform.position - target.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3( vectorX, target.transform.position.y+startPos.y, target.transform.position.z+ startPos.z);
        if(vectorX!= target.position.x)
        {

        }
    }
}
