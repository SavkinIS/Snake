using NewSnake;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    Color color;

    [SerializeField] ParticleSystem[] particlesFountains;

    void Start()
    {
        color = transform.parent.GetComponent<ColorPath>().GetColorGood;
        foreach (var item in particlesFountains)
        {
            item.Stop(true,ParticleSystemStopBehavior.StopEmittingAndClear);         
            ParticleSystem.MainModule psMain = item.main;
            psMain.startColor = new ParticleSystem.MinMaxGradient(color, color);
            item.Play(true);
        }

        Material material = GetComponent<MeshRenderer>().material;
        material.color = color;
    }
    void OnTriggerEnter(Collider colider)
    {
        if(colider.TryGetComponent<MoveHead>(out MoveHead snake))
        {
            snake.SetColor(color);
        }
        
    }

}
