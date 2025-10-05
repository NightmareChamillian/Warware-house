using UnityEngine;

public class HitDetector : MonoBehaviour, IOnBulletHit
{
    //The object that is hit
    public GameObject target;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //Called by the bullet that collides with the attached object
    //Calls the EnemyHit function of the specific object
    public void OnBulletHit(Bullet bullet)
    {
        IEnemyHandler enemyScript = target.GetComponent<IEnemyHandler>();
        enemyScript.EnemyHit(bullet);
    }
}