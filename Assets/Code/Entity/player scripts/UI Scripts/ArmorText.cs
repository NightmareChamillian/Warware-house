using TMPro;
using UnityEngine;

public class ArmorText : MonoBehaviour
{
    [SerializeField] private TMP_Text armorText;
    [SerializeField] private HealthGeneric healthHolder;

    void Start()
    {
        healthHolder = transform.parent.parent.GetComponent<HealthGeneric>();
    }


    void Update()
    {
        double currentArmor = healthHolder.GetArmor();
        double maxArmor = 3f;   // TODO: need to set this in HealthGeneric

        armorText = GetComponent<TMP_Text>();
        armorText.text = currentArmor + "/" + maxArmor;
    }
}
