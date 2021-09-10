using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [Tooltip("Скорость движения")]
    [SerializeField] protected float speed;

    /// <summary>
    /// Возможно ли движение
    /// </summary>
    protected bool canMove;

    void Start()
    {
        canMove = true;
    }

    /// <summary>
    /// Останавливает движение
    /// </summary>
    internal protected void Stop()
    {
        speed = -1;
        canMove = false;
    }


     
}
