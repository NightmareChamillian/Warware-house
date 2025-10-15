using UnityEngine;

public class EnemyMineCollisionRange : MonoBehaviour
{
    public GameObject parent;
    EnemyMine mine;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // get a reference to the parent mine script so we can tell it when something steps on us
        mine = parent.GetComponent<EnemyMine>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        mine.Detonate();
    }
}
