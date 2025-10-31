using System.Collections;
using UnityEngine;

public class ShooterStraight : MonoBehaviour, IShooter
{
    public GameObject bulletPrefab;
    public float roundsPerMinute;

    bool canFire = true;

    public ParticleSystem muzzleFlash;
    public ParticleSystem casings;

    public bool isAutomatic = false;
    bool letGoOfShootButton = true;

    public void Shoot()
    {
        if (!isAutomatic && !letGoOfShootButton)
        {
            return;
        }
        if (canFire)
        {
            Bullet bullet = Instantiate(bulletPrefab, transform.position + 1.5f * transform.forward, transform.rotation).GetComponent<Bullet>();
            StartCoroutine(Cooldown());

            DoEffects();

            letGoOfShootButton = false;
        }
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
    
    public void LetGoOfShootButton()
    {
        letGoOfShootButton = true;
    }
}
