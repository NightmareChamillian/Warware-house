using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using System;
public class PlayerMove : MonoBehaviour
{

    //movement keys
    public KeyControl forwardKey;
    public KeyControl backKey;
    public KeyControl leftKey;
    public KeyControl rightKey;
    public KeyControl pauseKey;
    //

    public Key customMapping = Key.UpArrow;//public variable so you can see the names of new keys you want to assign

    //speed variables
    private float sideSpeed = 0.1f; 
    private float forSpeed = 0.1f; 
    public float maxWalkSpeed = 26; //what's the MOST speed we can get up to?

    //we use these to track WASD inputs
    private bool[] nowPressed = {false,false,false,false}; //same as below but for the now
    private bool[] wasPressed = {false,false,false,false}; //W,A,S,D array we use to keep track of keys having JUST been pressed, used for stopping


    //these two values are our speed each frame.
    private float forBack = 0;
    private float sideSide = 0;



    //HERE ARE ALL MOUSE VARIABLES

    public float mouseSensitivity = 0.3f; //multiplier applied to mouse movements, test before doing anything with this
    public Vector2 mouse; //vector2 used to grab the x and y components from inputsystem call
    float vertRotation = 0; //up/down rotation, kept between frames
    private bool takingMouseInput = true;
    public Transform ourCamera;
    

    // setup function
    void Start()
    {
        //assign all our keycontrols
      forwardKey = Keyboard.current[Key.W];
      backKey = Keyboard.current[Key.S];

      leftKey = Keyboard.current[Key.A];
      rightKey = Keyboard.current[Key.D];

      pauseKey = Keyboard.current[Key.Escape];

      //lock the cursor so we don't move out of window 
      Cursor.lockState = CursorLockMode.Locked;
    }



    // Update is called once per frame
    void Update()
    {

        checkKeyboardInput();

        //give a boost once we've passed the threshhold. this emulates momentum, but in a simpler way.
        if(forBack > 2){
            forSpeed = 0.3f; 
        }
        if(sideSide > 2){
            sideSpeed = 0.3f; 
        }
        //blehhhh do it for negatives as well
        if(forBack < 0-2){
            forSpeed = 0.3f; 
        }
        if(sideSide < 0-2){
            sideSpeed = 0.3f; 
        }



        //check to see if we WERE pressing a movement key and no longer are. This will "break" any speed we've acculmulated.
        if(wasPressed[0] || wasPressed[2]){ //forwards back
            if(!(nowPressed[0] || nowPressed[2])){ //gotta love demorgansing boolean statements
                forBack = 0;
                forSpeed = 0.1f; 
            }
        }

        if(wasPressed[1] || wasPressed[3]){ //and again for side-side
            if(!(nowPressed[1] || nowPressed[3])){ 
                sideSide = 0;
                sideSpeed = 0.1f; 
            }
        }


        //update our wasPressed array for next frame
        wasPressed[0] = nowPressed[0];
        wasPressed[1] = nowPressed[1];
        wasPressed[2] = nowPressed[2];
        wasPressed[3] = nowPressed[3];


        //finally, clamp our movement. this does little right now but will be very important later when we have things like sprinting/aiming/crouching movespeed modifiers
        forBack = Mathf.Clamp(forBack, 0-maxWalkSpeed, maxWalkSpeed);
        sideSide = Mathf.Clamp(sideSide, 0-maxWalkSpeed, maxWalkSpeed);

        //go through with what we've done
        executeMotion();

        //if we want to move the camera, do it
        if(takingMouseInput){
            doMouse();}
    }

//check all the keycontrol objects, update our variables
private void checkKeyboardInput(){
        
        if(pauseKey.wasReleasedThisFrame){ // don't use isPressed, since that will run for every frame the button is held
            takingMouseInput = !takingMouseInput;
        }

        if(forwardKey.isPressed){
            forBack += forSpeed;
           nowPressed[0] = true; }
        else{
            nowPressed[0] = false;
        }

        if(backKey.isPressed){
            forBack -= forSpeed;
            nowPressed[2] = true;}
        else{
            nowPressed[2] = false;
        }

        if(leftKey.isPressed){
            sideSide -= sideSpeed;
           nowPressed[1] = true;} 
        else{
            nowPressed[1] = false;
        }

        if(rightKey.isPressed){
            sideSide += sideSpeed;
           nowPressed[3] = true;} 
        else{
            nowPressed[3] = false;
        }

}
    //private Vector3 velocity;

    private void executeMotion(){ // Check our pressed keys, move, and refresh. Doesn't do much, YET.

        transform.Translate(sideSide * Time.deltaTime, 0, forBack * Time.deltaTime); //stays local to the object

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

        transform.Rotate(0f, mouseX, 0f);
        ourCamera.transform.localRotation = Quaternion.Euler(vertRotation, 0f, 0f);
        

        //transform.localRotation = Quaternion.Euler(vertRotation, 0f, 0f);
        //playerTransform.Rotate(0, mouseX, 0);
    }

    //depreciated since I added the waspressed and nowpressed arrays which will refresh situationally

    // private void refreshKeys(){ //refresh our keypresses for the next frame

    //     forBack = 0;
    //     sideSide = 0;
    // }

    //destroy(ENTITY); //queue for deletion
}

