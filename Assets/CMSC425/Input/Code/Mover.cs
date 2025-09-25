using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class Mover : MonoBehaviour
{
    public float speed = 2;
    public Key forwardMove = Key.UpArrow;
    public Key backwardMove = Key.DownArrow;
    KeyControl forwardKey;
    KeyControl backwardKey;
    
    float dps;

    void Start()
    {
        forwardKey = Keyboard.current[forwardMove];
        backwardKey = Keyboard.current[backwardMove];
    }
    void Update()
    {
        if (forwardKey.isPressed)
        {
            transform.Translate(0, 0, Time.deltaTime * speed);
        }

        if (backwardKey.isPressed)
        {
            transform.Translate(0, 0, -Time.deltaTime * speed);
        }
    }
}
