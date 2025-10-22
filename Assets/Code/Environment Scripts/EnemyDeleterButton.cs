using UnityEngine;

/*
 * When shot, the button calls the EnemySpawner DeleteEnemies function in the parent room
 */
public class EnemyDeleterButton : MonoBehaviour, IOnBulletHit
{
    private EnemySpawner spawnerScript;

    public void OnBulletHit(DamageInfo info)
    {
        spawnerScript.DeleteEnemies();
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
