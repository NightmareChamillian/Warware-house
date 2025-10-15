using UnityEngine;

public class TestRoomSpawnpoints : MonoBehaviour, ISpawnpoints
{
    //The room's spawnpoints from (0, 0, 0)
    private Vector3[] spawnpoints000 = 
        { new Vector3(0f, 1.5f, 0f), new Vector3(1f, 1.5f, 0f), new Vector3(2f, 1.5f, 0f), new Vector3(-1f, 1.5f, 0f), new Vector3(-2f, 1.5f, 0f),
        new Vector3(1f, 1.5f, 1f), new Vector3(2f, 1.5f, 1f), new Vector3(-1f, 1.5f, 1f), new Vector3(-2f, 1.5f, 1f),
        new Vector3(1f, 1.5f, 2f), new Vector3(2f, 1.5f, 2f), new Vector3(-1f, 1.5f, 2f), new Vector3(-2f, 1.5f, 2f),
        new Vector3(1f, 1.5f, -1f), new Vector3(2f, 1.5f, -1f), new Vector3(-1f, 1.5f, -1f), new Vector3(-2f, 1.5f, -1f),
        new Vector3(1f, 1.5f, -2f), new Vector3(2f, 1.5f, -2f), new Vector3(-1f, 1.5f, -2f), new Vector3(-2f, 1.5f, -2f)
        };
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    Vector3[] ISpawnpoints.getSpawnpoints()
    {
        Vector3[] spawnpoints = new Vector3[spawnpoints000.Length];
        for (int i = 0; i < spawnpoints000.Length; i++)
        {
            spawnpoints[i] = spawnpoints000[i] + transform.position;
        }

        return spawnpoints;
    }
}
