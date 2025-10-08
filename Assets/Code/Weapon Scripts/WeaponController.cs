using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponController : MonoBehaviour
{
    public GameObject bulletPrefab;

    public void Shoot()
    {
        Instantiate(bulletPrefab, transform.position + 0.5f * transform.forward, transform.rotation);
    }
}
