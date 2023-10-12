using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    public static Action OnGamePaused;
    public static Action OnGameUnpaused;

    private PlayerControls _gameControls;
    private static bool _isGamePaused;

    private void Awake()
    {
        _gameControls = new PlayerControls();
    }

    private void Start()
    {
        _isGamePaused = false;
        _gameControls.UI.Pause.performed += PauseAction;
    }

    private void OnEnable()
    {
        _gameControls.UI.Enable();
    }

    private void OnDisable()
    {
        _gameControls.UI.Disable();
    }

    public static void TogglePauseMenu()
    {
        if(GameManager.Instance.IsGameOver()) return;
        _isGamePaused = !_isGamePaused;
        if (_isGamePaused)
        { 
            Time.timeScale = 0f;
            OnGamePaused?.Invoke();
        }
        else 
        { 
            Time.timeScale = 1f;
            OnGameUnpaused?.Invoke();
        }   
    }
    
    private void PauseAction(InputAction.CallbackContext context)
    {
        TogglePauseMenu();
    }
}
