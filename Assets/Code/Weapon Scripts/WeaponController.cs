using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponController : MonoBehaviour
{
    public GameObject bulletPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // using unity event. when this action happens, it calls the following onmouseclick method

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnMouseClick();
        }
    }

    void OnMouseClick()
    {
        Instantiate(bulletPrefab, transform.position + 2 * transform.forward, transform.rotation);
    }
}
