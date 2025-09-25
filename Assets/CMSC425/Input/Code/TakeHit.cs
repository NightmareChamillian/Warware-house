using System;
using UnityEngine;

public class TakeHit : MonoBehaviour
{
    System.Random rand = new System.Random();

    Func<float, float> r;

    void Start()
    {
        r = (s) => (float)(s * 2 * (rand.NextDouble() - .5));
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);

        transform.position = new Vector3(r(5), 0, r(5));
        transform.eulerAngles = new Vector3(0, r(180), 0);
    }
}
