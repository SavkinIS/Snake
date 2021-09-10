using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Компенсирует отставание при повороте головы змеи
/// </summary>
public class RotationCompensationSpeed : Move 
{ 
   
    void Update()
    {
        if(canMove) transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

}
