using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanTake : MonoBehaviour
{
    void OnTriggerEnter(Collider colider)
    {
        if (colider.TryGetComponent(out SnakeMovment snake))
        {
            Destroy(gameObject);
        }
    }
}
