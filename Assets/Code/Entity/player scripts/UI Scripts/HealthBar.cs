using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image filledBar;
    public Gradient healthColorGradient;

    public double maxHP;
    public double maxArmor;
    public double currentHP;
    public double currentArmor;
    public HealthGeneric healthHolder;

    void Start()
    {
        maxHP = 100;

        // retrieves health holder from player object
        healthHolder = transform.parent.parent.GetComponent<HealthGeneric>();
    }

    /*
     * AJ: gets health info from healthHolder, then applies changes to health bar
     * health bar has color gradient effect based on current health of player
     */
    void Update()
    {
        currentHP = healthHolder.GetHealth();
        currentArmor = healthHolder.GetArmor();
        
        // Debug.Log("current HP: " + currentHP);
        filledBar.fillAmount = (float)(currentHP / maxHP);
        filledBar.color = healthColorGradient.Evaluate(filledBar.fillAmount);
    }
}
