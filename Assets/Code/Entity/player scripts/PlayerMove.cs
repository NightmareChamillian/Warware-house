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
    
    //

    public Key customMapping = Key.UpArrow;//public variable so you can see the names of new keys you want to assign

    //speed variables
    private float defSpeed = 1f; //default starting speed
    private float sideSpeed = 1f; 
    private float forSpeed = 1f; 
    private float speedThresh = 6f; //threshhold required to give an agility bonus
    private float speedBonus = 2f; //agility bonus
    public float maxWalkSpeed = 26; //what's the MOST speed we can get up to?

    //we use these to track WASD inputs
    private bool[] nowPressed = {false,false,false,false}; //same as below but for the now
    private bool[] wasPressed = {false,false,false,false}; //W,A,S,D array we use to keep track of keys having JUST been pressed, used for stopping


    //these two values are our speed each frame.
    private float forBack = 0;
    private float sideSide = 0;

    private Rigidbody playerbody;
    private Vector3 playerVel; //reference to current velocity, grabbed at the start of every cycle and updated at the end in executemotion()
    
    

    // setup function
    void Start()
    {
        //assign all our keycontrols
      forwardKey = Keyboard.current[Key.W];
      backKey = Keyboard.current[Key.S];

      leftKey = Keyboard.current[Key.A];
      rightKey = Keyboard.current[Key.D];

      

      //lock the cursor so we don't move out of window 
      Cursor.lockState = CursorLockMode.Locked;

      playerbody = gameObject.GetComponent<Rigidbody>();
    }



    // Update is called once per frame
    void Update()
    {
        //playerVel = gameObject.GetComponent<Rigidbody>().linearVelocity; I thought I wanted this but I actually didn't

        checkKeyboardInput();

        //give a boost once we've passed the threshhold. this emulates momentum, but in a simpler way.
        if(forBack > speedThresh){
            forSpeed = speedBonus; 
        }
        if(sideSide > speedThresh){
            sideSpeed = speedBonus; 
        }
        //blehhhh do it for negatives as well
        if(forBack < speedThresh){
            forSpeed = speedBonus; 
        }
        if(sideSide < speedThresh){
            sideSpeed = speedBonus; 
        }



        //check to see if we WERE pressing a movement key and no longer are. This will "break" any speed we've acculmulated.
        if(wasPressed[0] || wasPressed[2]){ //forwards back
            if(!(nowPressed[0] || nowPressed[2])){ //gotta love demorgansing boolean statements
                forBack = 0;
                forSpeed = defSpeed; 
            }
        }

        if(wasPressed[1] || wasPressed[3]){ //and again for side-side
            if(!(nowPressed[1] || nowPressed[3])){ 
                sideSide = 0;
                sideSpeed = defSpeed;
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
        calcMotion();
        //handleFriction();
        executeMotion();

        

    }

//check all the keycontrol objects, update our variables
private void checkKeyboardInput(){
        


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
    private void calcMotion(){

        // if(forBack > 0){
        //     Debug.Log("Attempting to move forwards with rigidbody.");
        //     playerbody.AddForce(new Vector3(0, 0, 100), );//linearVelocity = ;
        // }
       
        playerVel = new Vector3(sideSide * Time.deltaTime * 60, 0, forBack * Time.deltaTime * 60);

    }

    private void executeMotion(){ // Check our pressed keys, move, and refresh. Doesn't do much, YET.

        //transform.Translate(sideSide * Time.deltaTime, 0, forBack * Time.deltaTime); //stays local to the object
        playerbody.AddForce(playerVel, ForceMode.Acceleration);
        //gameObject.GetComponent<Rigidbody>().linearVelocity = playerVel;
        return;
    }


    //depreciated since I added the waspressed and nowpressed arrays which will refresh situationally

    // private void refreshKeys(){ //refresh our keypresses for the next frame

    //     forBack = 0;
    //     sideSide = 0;
    // }

    //destroy(ENTITY); //queue for deletion
}

