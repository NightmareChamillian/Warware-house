using Unity.VisualScripting;
using UnityEngine;

public class DamageInfo{
    public double damageAmount; //raw damage

    public int damageType; //type, optional

    public GameObject origin; //user of the weapon, passed down from the weapon script, to the bullet script, finally to us

    public DamageInfo(double amt, int type, GameObject source)
    {
        damageAmount = amt;
        damageType = type;
        origin = source;
    }
    
    public double GetDamageAmount()
    {
        return damageAmount;
    }
}
