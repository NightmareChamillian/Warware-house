using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class Shooter : MonoBehaviour
{
    public Key shootCode = Key.RightShift;
    public GameObject shot;

    KeyControl shootKey;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        shootKey = Keyboard.current[shootCode];
    }

    void Update()
    {
        if (shootKey.wasPressedThisFrame)
        {
            Instantiate(shot, transform.position + 2 * transform.forward, transform.rotation);
        }
    }
}
