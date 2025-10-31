using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float roundsPerMinute;

    bool canFire = true;

    public ParticleSystem muzzleFlash;
    public ParticleSystem casings;

    public bool isAutomatic = false;
    bool letGoOfShootButton = true;

    public bool limitedAmmo = false;
    public int magSize = 10;
    int currentBulletsInMag;

    public void Start()
    {
        currentBulletsInMag = magSize;
    }

    public void Shoot()
    {
        // for semi autos
        if (!isAutomatic && !letGoOfShootButton)
        {
            return;
        }

        if (canFire)
        {
            // if mag empty we cant shoot
            if (currentBulletsInMag <= 0)
                return;

            Bullet bullet = Instantiate(bulletPrefab, transform.position + 1.5f * transform.forward, transform.rotation).GetComponent<Bullet>();
            StartCoroutine(Cooldown());

            DoEffects();

            letGoOfShootButton = false;

            if (limitedAmmo)
                currentBulletsInMag--;
        }
    }

    public void Reload()
    {
        if (!limitedAmmo)
            return;

        // change this when we have ammo pool, would refill less if not enough ammo for full mag
        currentBulletsInMag = magSize;
    }

    private IEnumerator Cooldown()
    {
        canFire = false;
        // prevent shooting faster than the rpm
        yield return new WaitForSeconds(60 / roundsPerMinute);
        canFire = true;
    }

    void DoEffects()
    {
        if (muzzleFlash != null)
            // emit 30 particles of flash
            muzzleFlash.Emit(30);
        if (casings != null)
            // emit just the 1 casing particle
            casings.Emit(1);
    }
    
    // used to track when the player pulls/releases trigger for automatic vs semi
    public void LetGoOfShootButton()
    {
        letGoOfShootButton = true;
    }
}
