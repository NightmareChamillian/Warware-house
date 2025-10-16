using UnityEngine;

public class Player : Entity, IOnBulletHit
{
    public double health;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnBulletHit(DamageInfo damageInfo)
    {
        health -= damageInfo.damageAmount;
        Debug.Log("health is " + health.ToString());
        return;
    }
}
