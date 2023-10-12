using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public static Action OnScorePanelActivated;
    public static Action OnWallHpModified;
    public static Action OnBrickPickedUp;

    public enum State
    {
        WaitingToStart,
        GamePlaying,
        GameOver,
    }

    private State _state;

    private float _gameTime;
    
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _state = State.GamePlaying;
    }

    private void FixedUpdate()
    {
        Debug.Log("State: " + _state);
        Debug.Log("GameTime: " + _gameTime);
        switch (_state)
        {
            case State.WaitingToStart:
                break;
            case State.GamePlaying:
                _gameTime += Time.deltaTime;
                if (Wall.Instance.GetCurrentHealth() <= 0 || Wall.Instance.GetCurrentHealth() >= Wall.Instance.GetMaxHealth())
                {
                    _state = State.GameOver;
                }
                break;
            case State.GameOver:
                OnScorePanelActivated?.Invoke();
                break;
        }
    }

    public bool IsGamePlaying()
    {
        return _state == State.GamePlaying;
    }

    public bool IsGameOver()
    {
        return _state == State.GameOver;
    }

    public float GetGameTime()
    {
        return _gameTime;
    }

    public void SetNewState(State state)
    {
        _state = state;
    }
}
