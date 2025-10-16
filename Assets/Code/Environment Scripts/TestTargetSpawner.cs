using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This spawner serves as a template to test room spawners with just the TestTarget
 * Implements random spawning in a room's spawnpoints up to a set number.
 * Implements destroying all remaining objects.
 * Does not implement random enemy selection or accessing danger levels.
 * Does not implement accessing IEnemyHandlers modularly
 */
public class TestTargetSpawner : MonoBehaviour
{
    //Test Target in the scene (Deprecated)
    //public GameObject testTarget;
    //private TestTarget testTargetScript;

    //Prefab to be instantiated
    public GameObject testTargetPrefab;

    //ISpawnpoints script attached to the room. Contains all the spawnpoints for the room
    private ISpawnpoints spawnpointsScript;

    //Array of spawnpoints, to be retrieved from the ISpawnpoints script attached to the room
    private Vector3[] spawnpoints;

    //Hardcoded for now. Would be a variable number according to the player's level.
    private int dangerLevel = 2;

    private List<GameObject> spawnedTargets;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnpointsScript = GetComponent<ISpawnpoints>();
        spawnpoints = spawnpointsScript.getSpawnpoints();
        //testTargetScript = testTarget.GetComponent<TestTarget>();
        spawnedTargets = new List<GameObject>();
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
            //This next line is not working
            /*
             * NullReferenceException: Object reference not set to an instance of an object
TestTarget.Respawn (UnityEngine.Vector3 position, UnityEngine.Quaternion rotation) (at Assets/Code/Entity/Enemy Scripts/TestTarget.cs:81)
TestTargetSpawner.SpawnEnemies () (at Assets/Code/Environment Scripts/TestTargetSpawner.cs:58)
TestTargetSpawner.Start () (at Assets/Code/Environment Scripts/TestTargetSpawner.cs:32)
             */
            //testTargetScript.Respawn(spawnpointsCopy[i], Quaternion.identity);

            //This line works
            GameObject newTestTarget = Instantiate(testTargetPrefab, spawnpointsCopy[i], Quaternion.identity);
            spawnedTargets.Add(newTestTarget);
        }
    }

    /*
     * Deletes all enemies spawned by SpawnEnemies()
     * Does not account for any targets not created by this class yet.
     */
    public void DeleteEnemies()
    {
        Debug.Log("Called DeleteEnemies");
        foreach(GameObject target in spawnedTargets)
        {
            if (target != null)
            {
                Destroy(target);
            }
        }
    }

}
