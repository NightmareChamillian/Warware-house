using UnityEngine;

// DEFAULT ENEMY CLASS! we will extend this for our enemies
// this is just so that we have a base class for stats and save on rewriting code
public class ShootingTarget : Enemy
{   
    public GameObject ourGun; 
    
    WeaponController weaponController;
   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    new public void Start()
    {   
        weaponController = ourGun.GetComponent<WeaponController>();
        Spawn();
    }

    // Update is called once per frame
    new void Update()
    {

    }

    
    //Called whenever the enemy is hit by a bullet
    //Calculates Test Target's health after a bullet hit
    //If health reaches 0, calls EnemyDeath()
    public override void OnBulletHit(DamageInfo info)
    {   
        doShoot();

        bool damResult = healthHolder.TakeDamage(info);
        Debug.Log(ENEMY_NAME + " hit for " + info.damageAmount + " damage. " +
            "It has " + healthHolder.GetHealth() + " health left");
        if (damResult)
        {
            EnemyDeath();
        }
    }

    public override void EnemyDeath()
    {
        //Debug.Log(ENEMY_NAME + " Died");
        Destroy(enemyObject);
        if(spawnerOrigin != null)
        {
            spawnerOrigin.EnemyDeath(enemyObject);
        }
        playerData.EnemyKilled();
    }

    private void doShoot(){
        weaponController.Shoot();
    }


}
