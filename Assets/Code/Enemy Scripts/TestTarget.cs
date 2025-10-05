using UnityEngine;
using UnityEngine.Rendering;

/*
 * Test Target has 40 hp and 1 armor at default. 
 * It is stationary and has no attack.
 * It respawns immediately upon death.
 */
public class TestTarget : MonoBehaviour, IEnemyHandler
{
    //The physical game object in the scene
    public GameObject testTarget;
    //The prefab used for spawning
    public GameObject testTargetPrefab;

    //Dies when hp hits 0
    private int health;
    //Reduce all damage taken by armor
    private int armor;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Spawn(testTarget);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Assigns the testObject parameter to the testTarget variable.
    //Then sets the Test Target's defensive stats
    public void Spawn(GameObject testObject)
    {
        testTarget = testObject;
        SetDefensiveStats(40, 1);
        Debug.Log("Test Target is at position " + transform.position);
    }
    //Sets the Test Target's health and armor
    public void SetDefensiveStats(int hp, int arm)
    {
        health = hp;
        armor = arm;
        Debug.Log("Initialized defensive stats. Test Target has " + health + " health and " + armor + " armor.");
    }
    //Calculates Test Target's health after a bullet hit
    //If health reaches 0, calls EnemyDeath()
    public void EnemyHit(Bullet bullet)
    {
        Debug.Log("Test Target was hit by a bullet. It took " + bullet.damage + " - " + armor + " damage.");
        health -= (int)bullet.damage - armor;
        Debug.Log("Test Target has " + health + " health left.");
        if(health <= 0)
        {
            EnemyDeath();
        }
    }
    //Destroys the Test Target, then calls Respawn with position x+2
    public void EnemyDeath()
    {
        Destroy(testTarget);
        Debug.Log("Test Target Died");
        Respawn(transform.position + 2*transform.right, transform.rotation);
    }
    //Spawns ta new Test Target prefab, then calls the new Test Target's Spawn function
    //and assigns its testTarget variable to the new object
    public void Respawn(Vector3 position, Quaternion rotation)
    {
        GameObject newTestTarget = Instantiate(testTargetPrefab, position, rotation);
        Debug.Log("Test Target Respawned at position " + position);
        TestTarget newTargetScript = newTestTarget.GetComponent<TestTarget>();
        newTargetScript.Spawn(newTestTarget);
    }

    
}
