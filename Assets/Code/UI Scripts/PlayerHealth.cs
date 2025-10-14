using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Image filledBar;
    public Gradient healthColorGradient;

    public double minHP, maxHP;
    public double currentHP;

    void Start()
    {
        minHP = 0;
        maxHP = 100;
        currentHP = 100;
    }


    void Update()
    {
        currentHP -= .1;
        filledBar.fillAmount = (float)(currentHP / maxHP);
        filledBar.color = healthColorGradient.Evaluate(filledBar.fillAmount);
    }
}
