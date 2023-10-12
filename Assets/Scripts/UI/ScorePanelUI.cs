using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScorePanelUI : MonoBehaviour
{
    [SerializeField] private Button restartLevelButton;
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private TextMeshProUGUI scoreText;
    
    private void Awake()
    {
        restartLevelButton.onClick.AddListener(() =>
        {
            //reload current scene
        } );
        
        mainMenuButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(0);
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
        timeText.text = "Your time: " + (int)GameManager.Instance.GetGameTime() + "s";
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
