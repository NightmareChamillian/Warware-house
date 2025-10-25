using UnityEngine;

public class HealthGeneric : MonoBehaviour, IHealthInterface
{


    private double ourHealth;

    private double ourArmor;
    private double armorDurability = 1.5; //rather than being 1:1, an armor being "defeated" is based off this ratio of incoming damage, on the armor's side.

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

        double reducedDamage = incomingDam.damageAmount - ourArmor;
        // if(reducedDamage < 1){ //if we fully "block" the attack, take 1 point of health and 1 point of armor.
        //     reducedDamage = 1;
        //     reduceArmor(1);

        //     Debug.Log("An object's armor  " + ourArmor + " has fully defeated " + incomingDam.damageAmount + " incoming damage");
        // }


        // //armor is lost at 1/durability times incoming damage. 
        // if(incomingDam.damageAmount > ourArmor * armorDurability){ //if damage is greater than armor * 2
        //     double armorLoss = incomingDam.damageAmount * (1/armorDurability);

        // }
        


        ourHealth -= reducedDamage;

        if(ourHealth <= 0){
            return true;
        }
        return false;
    }

    private reduceArmor(double amtBy){

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
