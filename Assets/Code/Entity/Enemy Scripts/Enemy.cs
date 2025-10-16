using UnityEngine;

// DEFAULT ENEMY CLASS! we will extend this for our enemies
// this is just so that we have a base class for stats and save on rewriting code
public class Enemy : MonoBehaviour//, IOnBulletHit
{
    public double health = 100;
    public int armor = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // default implementation for getting shot. subtract health by armor - bullet damage
    // this should be updated to use the new health system-- check docs/changelog for more info
    // public void OnBulletHit(DamageInfo info)
    // {
    //     health -= bullet.damage - armor;
    // }
}
