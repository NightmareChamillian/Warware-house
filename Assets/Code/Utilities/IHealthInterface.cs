public interface IHealthInterface{

    public bool TakeDamage(DamageInfo incomingDam);

    public double GetHealth();

    public double GetArmor();

    public void SetHealth(double newHealth);

    public void SetArmor(double newArmor);

    public void SetHealthAndArmor(double newHealth, double newArmor);

    

}
