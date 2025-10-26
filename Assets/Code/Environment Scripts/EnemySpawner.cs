using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

/*
 * Randomly spawns enemies in a room using the room's spawnpoints.
 * Implements generic application to all Enemy objects.
 * Implements random spawning in a room's spawnpoints up to a set number.
 * Implements destroying all remaining objects.
 * Implements adding dangerLevels to add up to the player's level and randomly selecting enemies that way.
 */
public class EnemySpawner : MonoBehaviour
{
    //Prefabs of all enemies to be instantiated
    public List<GameObject> enemyPrefabs;

    //ISpawnpoints script attached to the room. Contains all the spawnpoints for the room
    private ISpawnpoints spawnpointsScript;
    //Array of spawnpoints, to be retrieved from the ISpawnpoints script attached to the room
    private Vector3[] spawnpoints;

    //Player data
    private GameObject playerObject;
    private PlayerData playerData;
    private int playerLevel = 0;

    //Keeps track of all spawned enemies
    private List<GameObject> spawnedEnemies;

    //Room name. Would probably be read from the spawnpointsScript
    private string roomName = "Unnamed Room";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnpointsScript = GetComponent<ISpawnpoints>();
        spawnpoints = spawnpointsScript.getSpawnpoints();
        spawnedEnemies = new List<GameObject>();
        //Get the player data
        playerObject = GameObject.Find("Player");
        if (playerObject != null)
        {
            playerData = playerObject.GetComponent<PlayerData>();
        }
        else
        {
            Debug.Log("playerObject not found");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnEnemies()
    {
        Debug.Log("Called SpawnEnemies");
        playerLevel = playerData.GetPlayerLevel();
        Debug.Log("Player level is " + playerLevel);
        Vector3[] spawnpointsCopy = (Vector3[])spawnpoints.Clone();
        int combinedDangerLevels = 0;

        //Shuffle the copied array's order to be random
        for (int i = 0; i < spawnpointsCopy.Length; i++)
        {
            int randIndex = UnityEngine.Random.Range(i, spawnpointsCopy.Length);
            (spawnpointsCopy[i], spawnpointsCopy[randIndex]) = (spawnpointsCopy[randIndex], spawnpointsCopy[i]);
        }
        //Spawn randomly selected enemies up to the playerLevel
        while ( combinedDangerLevels < playerLevel && spawnedEnemies.Count < spawnpointsCopy.Length)
        {
            //Choose a random enemy
            int randomIndex = UnityEngine.Random.Range(0, enemyPrefabs.Count);
            GameObject selectedEnemy = enemyPrefabs[randomIndex];
            if(selectedEnemy != null)
            {
                Enemy selectedEnemyScript = selectedEnemy.GetComponent<Enemy>();
                if (selectedEnemyScript != null) {
                    //Check if the enemy is valid to be spawned
                    if (selectedEnemyScript.GetDangerLevel() + combinedDangerLevels <= playerLevel)
                    {
                        //Spawn the enemy
                        Debug.Log("Spawning " + selectedEnemyScript.GetName() + " at " + spawnpointsCopy[spawnedEnemies.Count]);
                        Debug.Log(selectedEnemyScript.GetName() + " has danger level " + selectedEnemyScript.GetDangerLevel());
                        GameObject newEnemy = Instantiate(selectedEnemy, spawnpointsCopy[spawnedEnemies.Count], Quaternion.identity);
                        //Updated the room's combined danger Level
                        combinedDangerLevels += selectedEnemyScript.GetDangerLevel();
                        //Debug.Log("combinedDangerLevels is " + combinedDangerLevels);
                        //Add the new enemy to the room's array of spawned enemies
                        spawnedEnemies.Add(newEnemy);
                        //Set the new enemy's origin to this script
                        newEnemy.GetComponent<Enemy>().SetOrigin(this);
                    }
                    else
                    {
                        //continue the loop
                    }
                }
                else
                {
                    throw new System.Exception("Selected enemy script not found");
                }
            } else
            {
                throw new System.Exception("Selected enemy didn't work");
            }
        }
    }
    /*
     * Deletes all enemies spawned by SpawnEnemies()
     * Does not account for any targets not created by this class.
     */
    public void DeleteEnemies()
    {
        Debug.Log("Called DeleteEnemies");
        //Loops backwards to destroy spawned enemies and clear the list of all entries
        for (int i = spawnedEnemies.Count - 1; i >= 0; i--)
        {
            if (spawnedEnemies[i] != null)
            {
                Destroy(spawnedEnemies[i]);
            }
            spawnedEnemies.RemoveAt(i);
        }
    }

    //Enemy scripts call this function when they die. Removes the enemy from the list of spawned enemies.
    //Then checks if all enemies have died. If so, calls RoomCleared()
    public bool EnemyDeath(GameObject killedEnemy)
    {
        Debug.Log("Calling EnemyDeath()");
        spawnedEnemies.Remove(killedEnemy);
        bool allDead = spawnedEnemies.Count == 0;
        Debug.Log("allDead is " +  allDead);
        if (allDead == true)
        {
            RoomCleared();
        }
        return allDead;
    }
    
    //Called when all enemies in the room have died. Increases the player's level. Hardcoded for now.
    public void RoomCleared()
    {
        playerData.IncreasePlayerLevel(3);
    }

    public string GetRoomName()
    {
        return roomName;
    }
}
