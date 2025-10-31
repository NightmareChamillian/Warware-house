using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponController : MonoBehaviour
{
    [SerializeField] Cooldown cooldown;
    public GameObject bulletPrefab;
    public GameObject weaponUser;

    public bool limitedAmmo = false;
    public int magSize = 10;
    //private bool doInaccuracy = false;
    //private bool inaccuracyAmount = 0;

    public void Shoot()
    {   
        if(limitedAmmo){ //ammo behavior
            if(magSize <=0){
                return;
            }
            magSize --;
        }

        // Check if weapon is on cooldown, prevent weapon shooting if true.   -AJ
        // Cooldown time can be set in the unity engine after being attached to weapon
        if (cooldown.IsCoolingDown())
        {
            Debug.Log("Unable to fire: Weapon is on cooldown");
            return;
        }
        
        Bullet ourBullet = Instantiate(bulletPrefab, transform.position + 0.5f * transform.forward, transform.rotation).GetComponent<Bullet>();
        ourBullet.ourOrigin = weaponUser; //give bullet ourselves so it can create damage info on impact

        // start cooldown after weapon has fired    -AJ
        cooldown.StartCooldown();
    }
}
