using System;
using TMPro;
using UnityEngine;

public class WallHealthAmountTextUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI wallHpText;

    private void Start()
    {
        UpdateText();
    }

    private void OnEnable()
    {
        GameManager.OnWallHpModified += UpdateText;
    }

    private void OnDisable()
    {
        GameManager.OnWallHpModified -= UpdateText;
    }

    private void UpdateText()
    {
        wallHpText.text = "Mur: " + Wall.Instance.GetCurrentHealth() + " / " + Wall.Instance.GetMaxHealth();
    }
}
