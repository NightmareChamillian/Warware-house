using UnityEngine;
using System;

public class EnemySoldier : Enemy
{
    // used to grab the weaponcontroller script we need, assign this in inspector
    public GameObject weapon;
    WeaponController weaponController;

    // this will assigned by some other script at some point when enemy is spawned
    //public Transform player;

    // used for controlling how fast the turret fires. interval is how many seconds btw shots
    float lastShotTime;
    float interval = 1f;

    // if we want to have something like smoke grenades or something else to block the line of sight
    // used in the player detection method
    public LayerMask obstructionMask;


    // the soldier's max movement speed
    private float MovementSpeed = 3f;
    // direction it's moving
    private Vector2 moveDirection = new Vector2(0, 0);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    new void Start()
    {
        //Initialized values for the drone
        health = 10;
        armor = 0;
        ENEMY_NAME = "Soldier Enemy";
        dangerLevel = 5;
        //Set the player value
        /*
        GameObject playerObject = GameObject.Find("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.Log("playerObject not found");
        }*/
        //Call parent Spawn
        base.Start();
        lastShotTime = Time.timeSinceLevelLoad;
        weaponController = weapon.GetComponent<WeaponController>();
    }

    // Update is called once per frame
    new void Update()
    {
        // if turret can see player, then turn towards player and shoot
        if (CanSeePlayer())
        {
            // get the direction of player and turn towards it
            Vector3 direction = (player.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            // quaternion lerp smoothly rotates towards the player
            transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * 5f);

            // simple cooldown for shooting. check if it has been 'interval' seconds since last shot
            if (Time.time >= lastShotTime + interval)
            {
                weaponController.Shoot();

                // reset cooldown
                lastShotTime = Time.time;
            }
        }

        // movement:
        // randomly chooses the move or stop
        if (UnityEngine.Random.Range(0, 100) == 0)
        {
            if (UnityEngine.Random.Range(0, 4) == 0) // sometimes it stops
            {
                moveDirection = new Vector2(0, 0); // sometimes it moves
            }
            else
            {
                float angle = UnityEngine.Random.Range(0f, 2 * Mathf.PI);
                moveDirection = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
            }
        }
        // changing the location
        transform.position = transform.position + new Vector3(moveDirection.x * Time.deltaTime * MovementSpeed, 0, moveDirection.y * Time.deltaTime * MovementSpeed);
    }

    // lowk expensive asf
    // (currently) every frame the turret is drawing a raycast from the turret's pos
    // to the players pos and check if theres anything in the way
    bool CanSeePlayer()
    {
        Vector3 directionToPlayer = (player.position - transform.position).normalized;
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // raycast to the player. only returns true if it directly hits the player
        if (Physics.Raycast(transform.position, directionToPlayer, out RaycastHit hit, distanceToPlayer, ~obstructionMask))
        {
            return hit.transform == player;
        }
        return false;
    }

    public override int GetDangerLevel()
    {
        //Hardcoded for now since I can't figure out how to override the variable outside of a function
        return 3;
    }
}
