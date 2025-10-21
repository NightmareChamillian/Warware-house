using UnityEngine;

[System.Serializable]

/* Determines how long has passed since last shot fired */
public class Cooldown
{
    [SerializeField] private float cooldownTime;
    private float fireInterval;

    public bool IsCoolingDown()
    {
        return Time.time < fireInterval;
    }

    public void StartCooldown()
    {
        fireInterval = Time.time + cooldownTime;
    }
}
