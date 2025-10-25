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
    public float defaultSpeed = 5f; //default starting speed. sidespeed and forspeed get set to this.
    private float sideSpeed = 1f; 
    private float forSpeed = 1f; 
    public float speedThresh = 10f; //threshhold required to give an agility bonus
    public float speedThreshBuff = 1f; //agility bonus
    public float maxWalkSpeed = 26; //what's the MOST speed we can get up to?
    public float walkSpeedMult = 5; //speed buff per frame
    public float maxSpeed = 20f;

    //we use these to track WASD inputs
    private bool[] nowPressed = {false,false,false,false}; //same as below but for the now
    private bool[] wasPressed = {false,false,false,false}; //W,A,S,D array we use to keep track of keys having JUST been pressed, used for stopping

    //these two values are our acculmulated "input"ness each frame.
    private float forBack = 0;
    private float sideSide = 0;

    //references for kinematic calculations
    private Rigidbody playerbody;
    public Transform playerCam;
    private Vector3 playerVel; //reference to current velocity, grabbed at the start of every cycle and updated at the end in executemotion()


    
    //friction values
    // public float fric = 10; //used in, get this, friction calculations 
    // public float stopSpeed = 40; // value we scale speed by to apply friction. if too high, won't work, if too low, will severely limit speed
    // public float speedFactor = 1; //how much do we want the player speed to be factored in? called control in most quakelike calculations.

    // setup function
    void Start()
    {

        sideSpeed = defaultSpeed;
        forSpeed = defaultSpeed;
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
        
        checkKeyboardInput();

        //give a boost once we've passed the threshhold. this emulates momentum, but in a simpler way.
        if(forBack > speedThresh){
            forSpeed = speedThreshBuff; 
        }
        if(sideSide > speedThresh){
            sideSpeed = speedThreshBuff; 
        }
        //blehhhh do it for negatives as well
        if(forBack < speedThresh){
            forSpeed = speedThreshBuff; 
        }
        if(sideSide < speedThresh){
            sideSpeed = speedThreshBuff; 
        }



        //check to see if we WERE pressing a movement key and no longer are. This will "break" any speed we've acculmulated.
        if(wasPressed[0] || wasPressed[2]){ //forwards back
            if(!(nowPressed[0] || nowPressed[2])){ //gotta love demorgansing boolean statements
                forBack = 0;
                forSpeed = defaultSpeed; 
            }
        }

        if(wasPressed[1] || wasPressed[3]){ //and again for side-side
            if(!(nowPressed[1] || nowPressed[3])){ 
                sideSide = 0;
                sideSpeed = defaultSpeed;
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
        executeMotion();
        //handleFriction();
 
        //finally, apply a speed limit
        Vector3 horizontalVel = playerbody.linearVelocity;
        horizontalVel.y = 0; //don't take into account falling
        if(horizontalVel.magnitude > maxSpeed){
            //Debug.Log("Limiting player speed!");
            horizontalVel *= maxSpeed / horizontalVel.magnitude;
            horizontalVel.y = playerbody.linearVelocity.y;
            playerbody.linearVelocity = horizontalVel;
        }

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

        //this produces a vector that gives WASD movement relative to the world coords.
        playerVel = transform.forward * forBack + transform.right * sideSide;
            

        //TODO: add a velocity check ehre as well
            
//            sideSide * Time.deltaTime * walkSpeedMult, 0,  * Time.deltaTime * walkSpeedMult);

       //what we need to do is factor in where the player's facing to this new playerVel vector.
       // float rotationAmount = Mathf.Rad2Deg * gameObject.transform.rotation.y;
        //Debug.Log(rotationAmount);
       //playerVel = Quaternion.AngleAxis(rotationAmount, Vector3.down) * playerVel; //well use quarternion.angleaxis for this, around the vert axis


        //sourcelike calculations but I didn't want to do full sourcelike so scrapping them blehhhh
        // Vector3 forwardVec = Vector3.Cross(Vector3.forward, -gameObject.transform.right);
        // Vector3 sideVec = Vector3.Cross(Vector3.forward, forwardVec);
        
        // Vector3 wishDir = forBack * forwardVec + sideSide * sideVec;
        // playerVel = wishDir; //will this work? no idea!


    }
    
    //applies sourcelike friction, but unity has their own friction, so this is weird and redundant
    // void handleFriction(){
    //     float playerSpeed = playerbody.linearVelocity.magnitude; //current speed of player. we don't ever actually change this, just use it as a quick reference.

    //     if(playerSpeed <= 0){ //player doesn't have speed, return early
    //         return;
    //     }

    //     if(playerSpeed > stopSpeed){
    //         speedFactor = playerSpeed / stopSpeed;
    //     }

    //     float drop = fric * Time.deltaTime * speedFactor; //calculate a drop in speed based on how fast we're going, our universal friction, and delta time
    //     float newSpeed = playerSpeed - drop; //our new ideal speed

    //     if(newSpeed < 0){
    //         newSpeed = 0; //don't ever acheive negative speed from friction
    //     }

    //     if(newSpeed != playerSpeed){
    //         newSpeed /= playerSpeed; //get proportion of old speed we're using
    //     }

    //     playerbody.linearVelocity *= newSpeed; //scale player's true speed by said value

    // }

    private void executeMotion(){ // Check our pressed keys, move, and refresh. Doesn't do much, YET.

        //transform.Translate(sideSide * Time.deltaTime, 0, forBack * Time.deltaTime); //stays local to the object
        playerbody.AddForce(playerVel, ForceMode.Acceleration); //i shouldn't do this actually
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

