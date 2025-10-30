using TMPro;
using UnityEngine;

public class KillCount : MonoBehaviour
{
    [SerializeField] private TMP_Text killCountText;
    [SerializeField] private PlayerData playerData;

    void Start()
    {
        playerData = transform.parent.parent.GetComponent<PlayerData>();
    }

    void Update()
    {
        int killCount = playerData.GetEnemiesKilled();
        killCountText = GetComponent<TMP_Text>();
        killCountText.text = "Enemies Unplugged: " + killCount;
    }
}
