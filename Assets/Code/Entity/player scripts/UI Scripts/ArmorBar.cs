using UnityEngine;
using UnityEngine.UI;

public class ArmorBar : MonoBehaviour
{
    Transform armorBar;
    public Image filledBar;
    public double maxArmor;
    public double currentArmor;
    public HealthGeneric healthHolder;
    void Start()
    {
        maxArmor = 3;

        // setting armor bar component
        armorBar = transform.Find("Armor Bar");
        filledBar = armorBar.GetComponent<Image>();

        // retrieves health holder from player object
        healthHolder = transform.parent.parent.GetComponent<HealthGeneric>();
    }

    void Update()
    {
        currentArmor = healthHolder.GetArmor();
        filledBar.fillAmount = (float)(currentArmor / maxArmor);
    }
}
