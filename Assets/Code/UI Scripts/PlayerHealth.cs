using System.Numerics;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health;

    public RectTransform healthBar;
    public float originalHealthBarSize;


    void Start()
    {
        originalHealthBarSize = healthBar.sizeDelta.x;
    }

    void Update()
    {
        
        healthBar.sizeDelta = new UnityEngine.Vector2(originalHealthBarSize * health / 100f, healthBar.sizeDelta.y);    // move to damage function when created
    }
}