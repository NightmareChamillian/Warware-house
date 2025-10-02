using UnityEngine;

public class HitDetector : MonoBehaviour, IOnBulletHit
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // this will be called by the bullet that collides
    public void OnBulletHit(Bullet bullet)
    {
        Debug.Log("I was hit by a bullet. I take " + bullet.damage + " damage.");
    }
}