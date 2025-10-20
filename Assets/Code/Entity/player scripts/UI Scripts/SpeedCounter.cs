using System;
using UnityEngine;

public class SpeedCounter : MonoBehaviour
{
    public Rigidbody rigidBody;
    float speed;

    void Update()
    {
        rigidBody = gameObject.GetComponent<Rigidbody>();
        speed = rigidBody.linearVelocity.magnitude;
        speed *= Time.deltaTime * 3600;
        speed = (float)Math.Round(speed, 2);
    }
    
    void OnGUI()
    {
        GUI.Label(new Rect(100, 100, 100, 100), "Speed Counter: " + speed);
    }
}