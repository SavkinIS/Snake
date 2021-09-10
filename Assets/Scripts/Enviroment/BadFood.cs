using NewSnake;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadFood : Food
{
    void Start()
    {
        manager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Check(other);
    }

}
