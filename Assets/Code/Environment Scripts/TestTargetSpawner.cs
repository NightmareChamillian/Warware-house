using System;
using UnityEngine;

/*
 * This spawner serves as a template to test room spawners with just the TestTarget
 * Implements random spawning in a room's spawnpoints up to a set number. 
 * Does not implement random enemy selection or accessing danger levels.
 * Does not implement accessing IEnemyHandlers modularly
 */
public class TestTargetSpawner : MonoBehaviour
{
    //Test Target in the scene
    public GameObject testTarget;

    private IEnemyHandler testTargetScript;

    //ISpawnpoints script attached to the room. Contains all the spawnpoints for the room
    private ISpawnpoints spawnpointsScript;

    //Array of spawnpoints, to be retrieved from the ISpawnpoints script attached to the room
    private Vector3[] spawnpoints;

    //Hardcoded for now. Would be a variable number according to the player's level.
    private int dangerLevel = 2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnpointsScript = GetComponent<ISpawnpoints>();
        spawnpoints = spawnpointsScript.getSpawnpoints();
        testTargetScript = testTarget.GetComponent<IEnemyHandler>();
        SpawnEnemies();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnEnemies()
    {
        Debug.Log("Called SpawnEnemies");
        Vector3[] spawnpointsCopy = (Vector3[])spawnpoints.Clone();

        //Shuffle the copied array's order to be random
        for (int i = 0; i < spawnpointsCopy.Length; i++)
        {
            int randIndex = UnityEngine.Random.Range(i, spawnpointsCopy.Length);
            (spawnpointsCopy[i], spawnpointsCopy[randIndex]) = (spawnpointsCopy[randIndex], spawnpointsCopy[i]);
        }

        //Spawn in TestTargets at the spawnpoints up to the dangerLevel
        for (int i = 0; i < dangerLevel && i < spawnpointsCopy.Length; i++)
        {
            Debug.Log("Spawning enemy at " + spawnpointsCopy[i]);
            testTargetScript.Respawn(spawnpointsCopy[i], Quaternion.identity);
            
        }
    }

}
