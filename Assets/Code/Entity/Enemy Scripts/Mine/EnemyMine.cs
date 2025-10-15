using UnityEngine;

public class EnemyMine : Enemy
{

    public float explosionRadius = 5f;
    public float explosionForce = 500f;

    public double damage = 40f;

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
        // get all of the colliders within a spherical radius from the mine
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        // for each of the colliders within the sphere, add some force to fling it away. this can be adjusted w/ explosion force value
        foreach (Collider nearby in colliders)
        {
            Rigidbody rb = nearby.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position - new Vector3(0, 0.5f, 0), explosionRadius);
            }

            // if the target implements ionbullethit then do damage to it
            IOnBulletHit target = nearby.gameObject.GetComponent<IOnBulletHit>();
            target?.OnBulletHit(new DamageInfo(damage, 0, gameObject));

            // delete the mine (change later when we add explosion)
            Destroy(gameObject);
        }
    }
}
