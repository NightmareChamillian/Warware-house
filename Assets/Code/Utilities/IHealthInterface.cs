public interface IHealthInterface{

    public bool takeDamage(DamageInfo incomingDam);

    public double getHealth();

    public double getArmor();

    public void setHealth(double newHealth);

    public void setArmor(double newArmor);

    public void setHealthAndArmor(double newHealth, double newArmor);

    

}
