/*Interface that all scripts for enemies should implement*/

using UnityEngine;

public interface IEnemyHandler
{
    //Called whenever the enemy is spawned
    public void Spawn(GameObject enemyObject);

    //Called when the enemy is hit
    public void EnemyHit(Bullet bullet);

    //Called when the enemy dies
    public void EnemyDeath();

    //Call to respawn the enemy
    public void Respawn(Vector3 position, Quaternion rotation);
}