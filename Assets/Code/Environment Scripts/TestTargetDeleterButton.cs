using UnityEngine;

/*
 * When shot, the button calls the TestTargetSpawner function
 * Does not work generically yet
 */
public class TestTargetDeleterButton : MonoBehaviour, IOnBulletHit
{
    private TestTargetSpawner spawnerScript;
    public void OnBulletHit(DamageInfo info)
    {
        spawnerScript.DeleteEnemies();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnerScript = GetComponentInParent<TestTargetSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
