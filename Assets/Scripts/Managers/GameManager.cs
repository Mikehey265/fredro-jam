using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public static Action OnScorePanelActivated;

    private enum State
    {
        WaitingToStart,
        GamePlaying,
        GameOver,
    }

    private State _state;
    
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _state = State.GamePlaying;
    }

    private void Update()
    {
        Debug.Log(_state);
        switch (_state)
        {
            case State.WaitingToStart:
                //slides
                break;
            case State.GamePlaying:
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
}
