using TMPro;
using UnityEngine;

public class DisplayLevel : MonoBehaviour
{
    [SerializeField] private TMP_Text playerLvlText;
    [SerializeField] private PlayerData playerData;

    void Start()
    {
        playerData = transform.parent.parent.GetComponent<PlayerData>();
    }
    
    void Update()
    {
        int playerLevel = playerData.GetPlayerLevel();
        playerLvlText = GetComponent<TMP_Text>();
        playerLvlText.text = "Lvl " + playerLevel.ToString();
    }
}
