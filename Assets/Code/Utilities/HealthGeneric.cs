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


    public bool takeDamage(DamageInfo incomingDam){ //take damage, and return true if it was lethal

        Debug.Log("An object has taken " + incomingDam.damageAmount + " Damage!");
        ourHealth -= incomingDam.damageAmount;

        if(ourHealth <= 0){
            return true;
        }
        return false;
    }

    public double getHealth(){
        return ourHealth;
    }

    public double getArmor(){
        return ourArmor;
    }

    public void setHealth(double newHealth){
        ourHealth = newHealth;
    }

    public void setArmor(double newArmor){
        ourArmor = newArmor;
    }

    public void setHealthAndArmor(double newHealth, double newArmor){
        ourHealth = newHealth;
        ourArmor = newArmor;
    }
}
