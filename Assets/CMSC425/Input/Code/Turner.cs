using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class Turner : MonoBehaviour
{
    public Key rightTurn = Key.RightArrow;
    public Key leftTurn = Key.LeftArrow;
    public float rpm = 10;
    KeyControl rightKey;
    KeyControl leftKey;
    
    float dps;
    void Start()
    {
        rightKey = Keyboard.current[rightTurn];
        leftKey = Keyboard.current[leftTurn];
    
        dps = 6 * rpm;
    }

    void Update()
    {
        if (rightKey.isPressed)
        {
            transform.Rotate(0, Time.deltaTime * dps, 0);
        }

        if (leftKey.isPressed)
        {
            transform.Rotate(0, -Time.deltaTime * dps, 0);
        }
    }
}
