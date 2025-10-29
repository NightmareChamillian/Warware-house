using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Transform healthBar;
    public Image filledBar;

    public Gradient healthColorGradient;

    public double maxHP;
    public double currentHP;
    public HealthGeneric healthHolder;

    void Start()
    {
        maxHP = 100;

        // setting health bar component
        healthBar = transform.Find("Health Bar");
        filledBar = healthBar.GetComponent<Image>();

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
        
        // Debug.Log("current HP: " + currentHP);
        filledBar.fillAmount = (float)(currentHP / maxHP);
        filledBar.color = healthColorGradient.Evaluate(filledBar.fillAmount);
    }
}
