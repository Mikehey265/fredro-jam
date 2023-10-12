using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public static Action OnScorePanelActivated;
    public static Action OnWallHpModified;
    public static Action OnBrickPickedUp;
    public static Action OnGameFinished;
    public static Action OnGameStarted;

    public enum State
    {
        SlidesBeforeStart,
        GamePlaying,
        GameOver,
        SlidesAfterFinish,
    }

    private State _state;

    private float _gameTime;
    
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _state = State.SlidesBeforeStart;
    }

    private void FixedUpdate()
    {
        Debug.Log(_state);
        switch (_state)
        {
            case State.SlidesBeforeStart:
                OnGameStarted?.Invoke();
                break;
            case State.GamePlaying:
                _gameTime += Time.deltaTime;
                if (Wall.Instance.GetCurrentHealth() <= 0 || Wall.Instance.GetCurrentHealth() >= Wall.Instance.GetMaxHealth())
                {
                    _state = State.SlidesAfterFinish;
                }
                break;
            case State.SlidesAfterFinish:
                OnGameFinished?.Invoke();
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
