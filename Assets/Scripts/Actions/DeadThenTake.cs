using NewSnake;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadThenTake : MonoBehaviour
{
    GameManager manager;

    private void Start()
    {
        manager = FindObjectOfType<GameManager>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<MoveHead>(out MoveHead snake))
        {
            if (!snake.GetIsRage) manager.GameOver();
            else {
                Destroy(gameObject);
             };
        }
    }
}
