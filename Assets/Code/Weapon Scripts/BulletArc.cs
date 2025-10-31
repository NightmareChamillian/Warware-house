using Unity.Multiplayer.Center.Common;
using UnityEngine;

public class BulletArc : MonoBehaviour
{
    public float speed = 50;
    public float lifetime = 10;
    public int damage = 5;
    public float gravityMultiplier = 1;

    Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.linearVelocity = transform.forward * speed;
        Destroy(gameObject, lifetime);
    }

    void FixedUpdate()
    {
        // add gravity for the arc
        rb.AddForce(new Vector3(0, -9.8f * gravityMultiplier, 0), ForceMode.Acceleration);
    }

    void OnCollisionEnter(Collision collision)
    {
        IOnBulletHit bulletHit = collision.gameObject.GetComponent<IOnBulletHit>();
        if (bulletHit != null)
        {
            // if bullethit.team != this.team, return. avoid ff
            bulletHit.OnBulletHit(new DamageInfo(damage, 0, null));

        }

        Destroy(gameObject);
    }
}
