using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public GameState CurrentState { get; private set; } = GameState.GAME;
    public event Action OnGameStateChanged;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        if (Instance != this)
            Destroy(this.gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public void SetGameState(GameState newState)
    {
        if (CurrentState == newState) return;

        CurrentState = newState;
        OnGameStateChanged?.Invoke();
    }
}

public enum GameState
{
    GAME,
    PAUSE,
    DEFEAT,
    WIN
}
