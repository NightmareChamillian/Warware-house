using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class MouseInputs : MonoBehaviour, IOnMouseDown
{
    public float mouseX; //up/down movement
    public float mouseY; //left/right movement
    public float mouseSensitivity = 1; //multiplier applied to mouse movements, test before doing anything with this
    public Vector2 mouse; //vector2 used to grab the x and y components from inputsystem call

    float xRotation = 0;
    float yRotation = 0;

    public int mouseCounter = 0; //rudimentary counter that changes when clicks happen. Does nothing(?)
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   

        //lock the cursor so we don't move out of window (but let's not for the time being)
        //Cursor.lockState = CursorLockMode.Locked; 
    }

    
    void Update()
    {
        // Legacy Input System
        // mouseX = Input.GetAxis("Mouse X");
        // mouseY = Input.GetAxis("Mouse Y");


        // New Input System
        mouse = Mouse.current.delta.ReadValue();
        mouseX = mouse.x * mouseSensitivity;
        mouseY = mouse.y * mouseSensitivity;

        //Debug.Log("mouse X: " + mouseX);
        //Debug.Log("mouse Y: " + mouseY);

        //up down rotation is disabled (for now) because we want it parented to the CAMERA. not the player. this will create a sense of a virtual body when the
        //player looks down as well as stop them from turning into a hard to hit hotdog when they look straight up. generally good behavior.
        //why not have the horizontal movement also parented to the camera? partially, to stop them from looking at the back of their playerbody, but also
        //so we can get the player's angle and direction without having to do too much weird conversion stuff.
        //I'm not married to this setup btw but IMO it's the best way to do things. - Rowan

        //xRotation -= mouseY;
        //xRotation = Mathf.clamp(mouseY, 90f, 90f); //clamp the up/down movement, keeps players from breaking their virtual "necks".

        yRotation += mouseX;




    }

    public void OnMouseDown() { //uses an Interface, has to be detailed by manager?
        if (mouseCounter == 0)
        {

            mouseCounter = 1;
        }
        else
        {

            mouseCounter = 0;
        }
    }
    

}
