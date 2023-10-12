using System;
using UnityEngine;
using UnityEngine.UI;

public class ScorePanelUI : MonoBehaviour
{
    [SerializeField] private Button restartLevelButton;
    [SerializeField] private Button mainMenuButton;
    
    private void Awake()
    {
        restartLevelButton.onClick.AddListener(() =>
        {
            //reload current scene
        } );
        
        mainMenuButton.onClick.AddListener(() =>
        {
            //load main menu scene
        } );
    }

    private void Start()
    {
        Hide();
        GameManager.OnScorePanelActivated += UpdateScorePanel;
    }

    private void OnDestroy()
    {
        GameManager.OnScorePanelActivated -= UpdateScorePanel;
    }

    private void UpdateScorePanel()
    {
        Show();
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
