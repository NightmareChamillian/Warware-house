using UnityEngine;

/*
 * When shot, the button calls the EnemySpawner SpawnEnemies function in the parent room
 */
public class EnemySpawnerButton : MonoBehaviour, IOnBulletHit
{
    private EnemySpawner spawnerScript;

    public void OnBulletHit(DamageInfo info)
    {
        spawnerScript.SpawnEnemies();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnerScript = GetComponentInParent<EnemySpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
