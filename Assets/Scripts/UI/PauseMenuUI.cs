using UnityEngine;
using UnityEngine.UI;

public class PauseMenuUI : MonoBehaviour
{
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button mainMenuButton;
    
    private void Awake()
    {
        resumeButton.onClick.AddListener(PauseMenu.TogglePauseMenu);
        
        restartButton.onClick.AddListener(() =>
        {
            //reload scene
            // Time.timeScale = 1f;
        } );
        
        mainMenuButton.onClick.AddListener(() =>
        {
            //return to main menu
        } );
    }

    private void Start()
    {
        PauseMenu.OnGamePaused += Show;
        PauseMenu.OnGameUnpaused += Hide;
        Hide();
    }

    private void OnDestroy()
    {
        PauseMenu.OnGamePaused -= Show;
        PauseMenu.OnGameUnpaused -= Hide;
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
