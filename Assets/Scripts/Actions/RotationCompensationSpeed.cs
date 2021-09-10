using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Compensates for the lag when turning the snake's head
/// </summary>
public class RotationCompensationSpeed : Move 
{ 
   
    void Update()
    {
        if(canMove) transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

}
