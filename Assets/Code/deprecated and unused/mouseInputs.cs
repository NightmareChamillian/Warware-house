// //this file is DEPRECATED and functionality has been merged with playerMove
// using UnityEngine;
// using System;
// using UnityEngine.InputSystem;
// using UnityEngine.InputSystem.Controls;




// public class MouseInputs : MonoBehaviour
// {
//     public float mouseSensitivity = 0.3f; //multiplier applied to mouse movements, test before doing anything with this
//     public Vector2 mouse; //vector2 used to grab the x and y components from inputsystem call

//     float xRotation = 0;

//     public playerTransform = null;

//     // Start is called once before the first execution of Update after the MonoBehaviour is created
//     void Start()
//     {
//         //lock the cursor so we don't move out of window 
//         Cursor.lockState = CursorLockMode.Locked;

//         playerBody = transform.parent; 
//     }


//     void Update() {

//         // New Input System
//         mouse = Mouse.current.delta.ReadValue();
//         float mouseX = mouse.x * mouseSensitivity;
//         float mouseY = mouse.y * mouseSensitivity;

//         // invert the mouse y rotation and clamp it so we dont move camera too far
//         xRotation -= mouseY;
//         xRotation = Mathf.Clamp(xRotation, -90f, 90f);

//         // apply rotations to the head and the body objects separately
//         // we do this so that the head can rotate up and down without changing body proportions
//         // and so that body will always be moving in the right direction
//         transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
//         playerTransform.Rotate(0, mouseX, 0);
//     }

// }
