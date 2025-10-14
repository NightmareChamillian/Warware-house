using UnityEngine;

public class EnemyMine : Enemy
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // this method will be called by the child when something enters it
    public void Detonate()
    {
        // explode
        Debug.Log("Mine explodes");
    }
}
