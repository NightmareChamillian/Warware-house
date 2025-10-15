using UnityEngine;

public class HealthGeneric : MonoBehaviour, IHealthInterface
{


    private double ourHealth;

    private double ourArmor;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public HealthGeneric(double startingHealth, double startingArmor){
        ourHealth = startingHealth;
        ourArmor = startingArmor;
    }


    public bool TakeDamage(DamageInfo incomingDam){ //take damage, and return true if it was lethal

        Debug.Log("An object has taken " + incomingDam.damageAmount + " Damage!");
        ourHealth -= incomingDam.damageAmount;

        if(ourHealth <= 0){
            return true;
        }
        return false;
    }

    public double GetHealth(){
        return ourHealth;
    }

    public double GetArmor(){
        return ourArmor;
    }

    public void SetHealth(double newHealth){
        ourHealth = newHealth;
    }

    public void SetArmor(double newArmor){
        ourArmor = newArmor;
    }

    public void SetHealthAndArmor(double newHealth, double newArmor){
        ourHealth = newHealth;
        ourArmor = newArmor;
    }
}
