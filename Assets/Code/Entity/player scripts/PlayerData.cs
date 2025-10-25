using UnityEngine;

public class PlayerData : Entity, IOnBulletHit
{
    public HealthGeneric healthHolder;
    // public double health;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        double maxHP = 100, maxArmor = 3;
        healthHolder = gameObject.GetComponent<HealthGeneric>();
        healthHolder.SetHealthAndArmor(maxHP, maxArmor);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnBulletHit(DamageInfo damageInfo)
    {
        /* AJ: testing out new health system */
        healthHolder.TakeDamage(damageInfo);

        // if (healthHolder.GetHealth() <= 0)
        // {
        //     Debug.Log("Player Died! Game Over :(");
        // }
        
        return;

        /* AJ: old health */
        // health -= damageInfo.damageAmount;
        // Debug.Log("health is " + health.ToString());
        // return;
    }
}
