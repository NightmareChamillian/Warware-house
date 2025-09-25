using UnityEngine;

public class Shot : MonoBehaviour
{
    public float speed = 10;
    public float lifetime = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    float timeLeft;
    void Start()
    {
        timeLeft = lifetime;
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;

        if (timeLeft <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
        }
    }
}
