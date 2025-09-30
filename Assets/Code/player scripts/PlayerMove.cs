using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
public class PlayerMove : MonoBehaviour
{



    private int speed = 13;


    //realizing we don't need these variables if we can just shove them in start()
    public Key forwardMapping = Key.UpArrow;
    public KeyControl forwardKey;

    //public Key backMove = ;
    public KeyControl backKey;
    public KeyControl leftKey;
    public KeyControl rightKey;

    // setup function
    void Start()
    {
        //assign all our keycontrols
      forwardKey = Keyboard.current[forwardMapping];
      backKey = Keyboard.current[Key.DownArrow];

      leftKey = Keyboard.current[Key.LeftArrow];
      rightKey = Keyboard.current[Key.RightArrow];
    }

    // Update is called once per frame
    void Update()
    {
        //check all the keycontrol objects

        if(forwardKey.isPressed){
           forBack += speed; } 
        if(backKey.isPressed){
            forBack -= speed; }

        if(leftKey.isPressed){
           sideSide -= speed; } 

        if(rightKey.isPressed){
           sideSide += speed; } 

        executeMotion();
    }

    private int forBack = 0;
    private int sideSide = 0;
    //private Vector3 velocity;

    private void executeMotion(){ // Check our pressed keys, move, and refresh


        transform.Translate(sideSide * Time.deltaTime, 0, forBack * Time.deltaTime); //stays local to the object
        refreshKeys();

    }

    private void refreshKeys(){ //refresh our keypresses for the next frame

        forBack = 0;
        sideSide = 0;
    }

    //destroy(ENTITY); //queue for deletion
}

