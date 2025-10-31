using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponController : MonoBehaviour
{
    [SerializeField] Cooldown cooldown;
    public GameObject bulletPrefab;
    public GameObject weaponUser;

    public void Shoot()
    {
        // Check if weapon is on cooldown, prevent weapon shooting if true.   -AJ
        // Cooldown time can be set in the unity engine after being attached to weapon
        if (cooldown.IsCoolingDown())
        {
            Debug.Log("Unable to fire: Weapon is on cooldown");
            return;
        }
        
        Bullet ourBullet = Instantiate(bulletPrefab, transform.position + 0.5f * transform.forward, transform.rotation).GetComponent<Bullet>();
        ourBullet.ourOrigin = weaponUser;

        // start cooldown after weapon has fired    -AJ
        cooldown.StartCooldown();
    }
}
