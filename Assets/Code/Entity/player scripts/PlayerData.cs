using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerData : Entity, IOnBulletHit
{
    public HealthGeneric healthHolder;
    // public double health;

    private int playerLevel;

    //Temporary solution to displaying level increase
    private int oldPlayerLevel;

    private int enemiesKilled;

    [SerializeField] private Transform player;
    [SerializeField] private GameObject enemyKilledTextObject;
    [SerializeField] private TMP_Text enemyKilledText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        double maxHP = 100, maxArmor = 3;
        healthHolder = gameObject.GetComponent<HealthGeneric>();
        healthHolder.SetHealthAndArmor(maxHP, maxArmor);

        playerLevel = 1;
        oldPlayerLevel = 1;

        player = transform;
        enemyKilledTextObject = GameObject.Find("Enemy Killed Text");
        enemyKilledText = enemyKilledTextObject.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator DisplayKillConfirmed()
    {
        //Check if level increased (temporary solution)
        if(oldPlayerLevel != playerLevel)
        {
            enemyKilledText.text = "Level Increased!";
            oldPlayerLevel = playerLevel;
            enemyKilledText.gameObject.SetActive(true);

            yield return new WaitForSeconds(3); 
        }
        else
        {
            enemyKilledText.text = "Enemy Killed!";
            enemyKilledText.gameObject.SetActive(true);

            yield return new WaitForSeconds(1);
        }

        enemyKilledText.gameObject.SetActive(false);

    }

    public void OnBulletHit(DamageInfo damageInfo)
    {
        healthHolder.TakeDamage(damageInfo);
        return;
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

        StartCoroutine(DisplayKillConfirmed());
    }
}
