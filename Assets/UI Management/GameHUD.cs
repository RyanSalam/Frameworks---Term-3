using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHUD : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private GameObject gameplayHUD;
    [SerializeField] private GameObject pauseMenuHUD;
    [SerializeField] private GameObject defeatHUD;
    [SerializeField] private GameObject victoryHUD;

    private Dictionary<GameState, GameObject> StateMenuLookup = new Dictionary<GameState, GameObject>();



    private void Awake()
    {
        StateMenuLookup.Add(GameState.GAME, gameplayHUD);
        StateMenuLookup.Add(GameState.PAUSE, pauseMenuHUD);
        StateMenuLookup.Add(GameState.DEFEAT, defeatHUD);
        StateMenuLookup.Add(GameState.WIN, victoryHUD);
    }

    private void Start()
    {
        GameManager.Instance.OnGameStateChanged += GM_StateChangedCallback;
    }

    private void GM_StateChangedCallback()
    {
        // Turn off all the HUDs first
        foreach (GameObject menu in StateMenuLookup.Values)
        {
            // You can make additional checks to see if gameobject is already inactive or not.
            menu.SetActive(false);
        }

        // Check if we contain a specific menu for the new game state.
        // Set that menu to be active.
        GameState currentState = GameManager.Instance.CurrentState;
        if (StateMenuLookup.ContainsKey(currentState))
        {
            StateMenuLookup[currentState].SetActive(true);
        }
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnGameStateChanged -= GM_StateChangedCallback;
    }
}
