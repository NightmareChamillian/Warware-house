using UnityEngine;

public class PlayerData : Entity, IOnBulletHit
{
    public HealthGeneric healthHolder;
    // public double health;

    private int playerLevel;

    private int enemiesKilled;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        double maxHP = 100, maxArmor = 3;
        healthHolder = gameObject.GetComponent<HealthGeneric>();
        healthHolder.SetHealthAndArmor(maxHP, maxArmor);

        playerLevel = 4;
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

    public int GetPlayerLevel()
    {
        return playerLevel;
    }

    public void IncreasePlayerLevel(int increase)
    {
        playerLevel += increase;
        Debug.Log("Player level increased by " + increase + ", it is now " +  playerLevel);
    }

    public int GetEnemiesKilled()
    {
        return enemiesKilled;
    }

    public void EnemyKilled()
    {
        enemiesKilled++;
        Debug.Log("Player has killed " + enemiesKilled + " enemies");
    }
}
