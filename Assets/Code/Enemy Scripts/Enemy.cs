using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject weapon;
    WeaponController weaponController;

    float lastShotTime;
    float interval = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lastShotTime = Time.timeSinceLevelLoad;
        weaponController = weapon.GetComponent<WeaponController>();
    }

    // Update is called once per frame
    void Update()
    {
        // simple timer. if the current time is 'interval' seconds past the last time we shot, shoot again and reset timer
        if (Time.timeSinceLevelLoad >= lastShotTime + interval)
        {
            weaponController.Shoot();

            lastShotTime = Time.timeSinceLevelLoad;
        }
    }
}
