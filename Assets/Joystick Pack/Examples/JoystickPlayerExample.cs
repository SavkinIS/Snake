using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickPlayerExample : MonoBehaviour
{
    public float speed;
    public FixedJoystick variableJoystick;
    public Rigidbody rb;

    public void FixedUpdate()
    {
        print(variableJoystick.Horizontal);
        Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
        //rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);

        transform.position = Vector3.MoveTowards(transform.position,(direction * speed * Time.fixedDeltaTime),1);
    }
}