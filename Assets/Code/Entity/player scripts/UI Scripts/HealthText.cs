using TMPro;
using UnityEngine;

public class HealthText : MonoBehaviour
{
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private HealthGeneric healthHolder;

    void Start()
    {
        healthHolder = transform.parent.parent.GetComponent<HealthGeneric>();
    }

    // Update is called once per frame
    void Update()
    {
        double currentHealth = healthHolder.GetHealth();
        double maxHealth = 100;     // TODO: set in HealthGeneric

        healthText = GetComponent<TMP_Text>();
        healthText.text = currentHealth + "/" + maxHealth;
    }
}
