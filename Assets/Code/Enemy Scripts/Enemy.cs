using UnityEngine;

// DEFAULT ENEMY CLASS! we will extend this for our enemies
// this is just so that we have a base class for stats and save on rewriting code
public class Enemy : MonoBehaviour, IOnBulletHit
{
    public int health = 100;
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
    public void OnBulletHit(Bullet bullet)
    {
        health -= bullet.damage - armor;
    }
}
