using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateSwitcher : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            GameManager.Instance.SetGameState(GameState.GAME);

        if (Input.GetKeyDown(KeyCode.Alpha2))
            GameManager.Instance.SetGameState(GameState.PAUSE);

        if (Input.GetKeyDown(KeyCode.Alpha3))
            GameManager.Instance.SetGameState(GameState.DEFEAT);

        if (Input.GetKeyDown(KeyCode.Alpha4))
            GameManager.Instance.SetGameState(GameState.WIN);
    }
}
