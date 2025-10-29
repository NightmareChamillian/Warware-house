using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class SpawnPoints : MonoBehaviour, ISpawnpoints
{
    public List<Transform> spawnPoints;

    public Vector3[] getSpawnpoints()
    {
        Vector3[] vecList = new Vector3[spawnPoints.Count];
        for (int i = 0; i < spawnPoints.Count; i++)
        {
            vecList[i] = spawnPoints[i].position;
        }

        return vecList;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
