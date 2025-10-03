using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class MouseInputs : MonoBehaviour, IOnMouseDown
{
    public float mouseX;
    public float mouseY;
    public Vector2 mouse;
    public int counter = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Legacy Input System
        // mouseX = Input.GetAxis("Mouse X");
        // mouseY = Input.GetAxis("Mouse Y");


        // New Input System
        mouse = Mouse.current.delta.ReadValue();
        mouseX = mouse.x;
        mouseY = mouse.y;

        Debug.Log("mouse X: " + mouseX);
        Debug.Log("mouse Y: " + mouseY);
    }

    public void OnMouseDown() { //uses an Interface, has to be detailed by manager?
        if (counter == 0)
        {

            counter = 1;
        }
        else
        {

            counter = 0;
        }
    }
    

}
