using UnityEngine;
using UnityEngine.UI;

public class PauseMenuUI : MonoBehaviour
{
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button mainMenuButton;
    
    private void Awake()
    {
        // resumeButton.onClick.AddListener( TogglePauseMenu );
        
        restartButton.onClick.AddListener(() =>
        {
            //reload scene
            Time.timeScale = 1f;
        } );
        
        mainMenuButton.onClick.AddListener(() =>
        {
            //return to main menu
        } );
    }
}
