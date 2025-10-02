using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 50;
    public float lifetime = 10;

    public float damage = 5;

    Vector3 currentPos;

    // bullet has a lifespan, will die after reaching it. prevents memory leaks if a bullet doesnt collide
    float timeLeft;

    void Start()
    {
        timeLeft = lifetime;
        currentPos = transform.position;
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            Destroy(gameObject);
        }


        /*
        solving the tunneling issue of collision because bullet is moving too fast

        we cast a ray from the current position to where the bullet will end up
        if theres something in the way, it would hit that in the current frame
        so we call its bullet hit method

        */
        Vector3 nextPos = transform.position + transform.forward * speed * Time.deltaTime;
        Vector3 direction = nextPos - currentPos;
        float distance = direction.magnitude;

        RaycastHit hit;
        if (Physics.Raycast(currentPos, direction.normalized, out hit, distance))
        {
            IOnBulletHit otherScript = hit.collider.gameObject.GetComponent<IOnBulletHit>();
            otherScript?.OnBulletHit(this);
            Destroy(gameObject);
            return;
        }

        transform.position = nextPos;
        currentPos = nextPos;
    }
}
