using UnityEngine;

// DEFAULT ENEMY CLASS! we will extend this for our enemies
// this is just so that we have a base class for stats and save on rewriting code
public class Enemy : MonoBehaviour, IOnBulletHit
{
    //Default variables for an enemy who doesn't initialize their own.
    public double health = 10; //This needs to be set in the inspector if changed
    public double armor = 0;
    public string ENEMY_NAME = "UNNAMED ENEMY";
    public int dangerLevel = 1;

    //The physical game object of the enemy in the scene 
    public GameObject enemyObject;

    //The player object, their position, and their data
    public GameObject playerObject;
    public Transform player;
    public PlayerData playerData;


    //The prefab used for spawning
    //public GameObject enemyObjectPrefab;

    public HealthGeneric healthHolder;
    //public HealthGeneric healthHolder;

    //The script that instantiated this Enemy
    public EnemySpawner spawnerOrigin;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    public void Update()
    {

    }

    //Sets the enemy's starting to values
    public void Spawn()
    {
        enemyObject = gameObject;
        //healthHolder = new HealthGeneric(health, armor);
        healthHolder = gameObject.GetComponent<HealthGeneric>();
        healthHolder.SetHealthAndArmor(health, armor);
        Debug.Log(ENEMY_NAME + " is at position " + transform.position);
        //Set the player value
        playerObject = GameObject.Find("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
            playerData = player.GetComponent<PlayerData>();
        }
        else
        {
            Debug.Log("playerObject not found");
        }
    }

    //Called whenever the enemy is hit by a bullet
    //Calculates Test Target's health after a bullet hit
    //If health reaches 0, calls EnemyDeath()
    public void OnBulletHit(DamageInfo info)
    {
        bool damResult = healthHolder.TakeDamage(info);
        Debug.Log(ENEMY_NAME + " hit for " + info.damageAmount + " damage. " +
            "It has " + healthHolder.GetHealth() + " health left");
        if (damResult)
        {
            EnemyDeath();
        }
    }

    public void EnemyDeath()
    {
        Debug.Log(ENEMY_NAME + " Died");
        Destroy(enemyObject);
        if(spawnerOrigin != null)
        {
            spawnerOrigin.EnemyDeath(enemyObject);
        }
        playerData.EnemyKilled();
    }

    public void SetOrigin(EnemySpawner spawnerScript)
    {
        spawnerOrigin = spawnerScript;
        Debug.Log(ENEMY_NAME + " origin set to " +  spawnerOrigin.GetRoomName());
    }

    public double GetHealth()
    {
        return health;
    }

    public double GetArmor()
    {
        return armor;
    }

    public string GetName()
    {
        return ENEMY_NAME;
    }

    public virtual int GetDangerLevel()
    {
        return dangerLevel;
    }
}
