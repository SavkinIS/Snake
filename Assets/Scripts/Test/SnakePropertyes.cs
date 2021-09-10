using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakePropertyes : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    SkinnedMeshRenderer skinned;
    Color color;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal void SetColor(Color newColor)
    {
        color = newColor;

        foreach (var item in skinned.materials)
        {
            if (item.name.Contains("Snake")) item.color = newColor;
        }
    }
}
