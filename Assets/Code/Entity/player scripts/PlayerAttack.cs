using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
public class PlayerAttack : MonoBehaviour
{


    //HERE ARE ALL MOUSE VARIABLES

    public float mouseSensitivity = 0.2f; //multiplier applied to mouse movements, test before doing anything with this
    public Vector2 mouse; //vector2 used to grab the x and y components from inputsystem call
    float vertRotation = 0; //up/down rotation, kept between frames

    //state variables
    private bool aimingSights = false;
   
    private bool takingMouseInput = true;

    //inputs
    public ButtonControl mousePrimary;
    public ButtonControl mouseSecondary;
    public KeyControl pauseKey;

    // references to other game objects
    public Transform ourCamera; //reference to the camera
    public GameObject weapon;
    IShooter shooter;

    void Start()
    {
        // set default shoot button to be left mouse
        mousePrimary = Mouse.current.leftButton;
        mouseSecondary = Mouse.current.rightButton;
        pauseKey = Keyboard.current[Key.Escape];

        // get the shooter script from our weapon
        shooter = weapon.GetComponent<IShooter>();
    }

    void Update()
    {
        if (mousePrimary.isPressed)
        {
            shooter.Shoot();
        }
        else if (mousePrimary.wasReleasedThisFrame)
        {
            shooter.LetGoOfShootButton();
        }
        
        if (mouseSecondary.wasPressedThisFrame){
            if (aimingSights){
                aimingSights = false;
                mouseSensitivity = 0.2f;
                
            }else{
                aimingSights = true;
                mouseSensitivity = 0.07f;
            }
        }

        if (pauseKey.wasPressedThisFrame)
        { // don't use isPressed, since that will run for every frame the button is held
            takingMouseInput = !takingMouseInput;
        }

        //if we want to move the camera, do it
        if (takingMouseInput)
        {
            doMouse();
        }
    }
    

    private void doMouse(){



         // New Input System
        mouse = Mouse.current.delta.ReadValue();
        float mouseX = mouse.x * mouseSensitivity;
        float mouseY = mouse.y * mouseSensitivity;

        // invert the mouse y rotation and clamp it so we dont move camera too far
        vertRotation -= mouseY;
        vertRotation = Mathf.Clamp(vertRotation, -90f, 90f);


        

        // apply rotations to the head and the body objects separately
        // we do this so that the head can rotate up and down without changing body proportions
        // and so that body will always be moving in the right direction

        transform.Rotate(0f, mouseX, 0f); //body traverses left/right
        ourCamera.transform.localRotation = Quaternion.Euler(vertRotation, 0f, 0f); //camera moves up/down
        
    }
}
