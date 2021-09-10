using NewSnake;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
     GameManager manager;

    private void Start()
    {
        manager = FindObjectOfType<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<MoveHead>(out MoveHead snake))
        {
            manager.Win();
        }
    }
}
