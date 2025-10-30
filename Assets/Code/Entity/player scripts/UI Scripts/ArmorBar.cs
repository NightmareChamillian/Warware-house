using System;
using UnityEngine;
using UnityEngine.UI;

public class ArmorBar : MonoBehaviour
{
    [SerializeField] private Transform armorBar1;
    [SerializeField] private Transform armorBar2;
    [SerializeField] private Transform armorBar3;
    [SerializeField] private Image[] filledBarArray;

    [SerializeField] private HealthGeneric healthHolder;
    [SerializeField] private double maxArmor;
    [SerializeField] double currentArmor;

    // retrieves armor bar UI objects and stores in array for later use
    void Start()
    {
        maxArmor = 3;

        // retrieves health holder from player object
        healthHolder = transform.parent.parent.GetComponent<HealthGeneric>();

        // setting armor bar component
        armorBar1 = transform.Find("Armor Bar 1");
        armorBar2 = transform.Find("Armor Bar 2");
        armorBar3 = transform.Find("Armor Bar 3");
        filledBarArray = new Image[3];
        filledBarArray[0] = armorBar1.GetComponent<Image>();
        filledBarArray[1] = armorBar2.GetComponent<Image>();
        filledBarArray[2] = armorBar3.GetComponent<Image>();
    }

    // UI will update armor bars when depleted or gained
    void Update()
    {
        currentArmor = healthHolder.GetArmor();

        for (int i = (int)maxArmor - 1; i >= currentArmor; i--)
        {
            filledBarArray[i].fillAmount = (i < currentArmor) ? 1 : 0;
        }
    }
}
