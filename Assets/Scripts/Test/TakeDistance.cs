using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDistance : MonoBehaviour
{
    SnakeMovment snake;
    void Start()
    {
        snake = FindObjectOfType<SnakeMovment>();
    }

    // Update is called once per frame
    void Update()
    {
      transform.position = new Vector3(transform.position.x , transform.position.y, snake.transform.position.z + 20);
    }
}
