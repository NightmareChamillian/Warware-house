using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    EnemySpawner enemySpawner;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemySpawner = gameObject.GetComponent<EnemySpawner>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EnterRoom()
    {
        if (enemySpawner != null)
            enemySpawner.SpawnEnemies();
    }

    public void ExitRoom()
    {
        if (enemySpawner != null)
            enemySpawner.DeleteEnemies();
    }
}
