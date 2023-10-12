using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    public static Action OnHealthModified;
    
    [SerializeField] private Image healthBarImage;

    private void Start()
    {
        UpdateHealthBar();
    }

    private void OnEnable()
    {
        OnHealthModified += UpdateHealthBar;
    }

    private void OnDisable()
    {
        OnHealthModified -= UpdateHealthBar;
    }

    private void UpdateHealthBar()
    {
        healthBarImage.fillAmount = Wall.Instance.GetCurrentHealth() / Wall.Instance.GetMaxHealth();
    }
}
