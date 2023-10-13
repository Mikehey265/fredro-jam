using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button creditsButton;
    [SerializeField] private Button quitButton;
    
    private void Awake()
    {
        playButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(1);
        } );
        
        creditsButton.onClick.AddListener(() =>
        {
            //load credits scene or show credits panel
        } );
        
        quitButton.onClick.AddListener(Application.Quit);

        Time.timeScale = 1f;
    }
}
