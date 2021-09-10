using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// движение назад
/// </summary>
public class MoveBack : Move
{
    [Tooltip("Множитель скорости")]
    [SerializeField] int SpeedMultiplier;

    /// <summary>
    /// Начальное значение скорости
    /// </summary>
    float startSpeed;
    

    void Start()
    {
        canMove = true;
        startSpeed = speed;
    }

    void Update()
    {
        if(canMove) transform.Translate(Vector3.back * speed * Time.deltaTime);
    }

    /// <summary>
    /// Увеличение скорости в режиме ярости
    /// </summary>
    /// <param name="durationOfRage"></param>
    internal void SpeedRage( float durationOfRage)
    {
        speed = speed * SpeedMultiplier;
    }

    /// <summary>
    /// Вернуть скорость к начальному значению
    /// </summary>
    internal void SetStartSpeed()
    {
        speed = startSpeed;
    }

}
