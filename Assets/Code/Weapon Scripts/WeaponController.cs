using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject weaponUser;

    public void Shoot()
    {   
        Bullet ourBullet = Instantiate(bulletPrefab, transform.position + 0.5f * transform.forward, transform.rotation).GetComponent<Bullet>();
        ourBullet.ourOrigin = weaponUser;
    }
}
