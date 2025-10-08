using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class PlayerAttack : MonoBehaviour
{
    public ButtonControl shootKey;

    // assign this in inspector
    public GameObject weapon;
    WeaponController weaponController;

    void Start()
    {
        // set default shoot button to be left mouse
        shootKey = Mouse.current.leftButton;

        // get the weapon controller script from our weapon
        weaponController = weapon.GetComponent<WeaponController>();
    }

    void Update()
    {
        // behavior for semi-automatics, shoot only when we click
        if (shootKey.wasPressedThisFrame)
        {
            weaponController.Shoot();
        }
    }
}
