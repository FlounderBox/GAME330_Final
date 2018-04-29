using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameEvent GameStartEvent;
    public GameEvent GameEndEvent;
    public GameEvent GamePauseEvent;
    public GameEvent GameActiveEvent;

    public float GameTime = 240;

    enum GameState
    {
        Start,
        Active,
        Pause,
        End
    }

    GameState currentState = GameState.Start;

    public static float GameTimer
    {
        get
        {
            return GameObject.FindObjectOfType<GameManager>().gameTimer;
        }
    }
    private float gameTimer;

    private void Awake()
    {
        gameTimer = GameTime;
        ChangeGameState(GameState.Active);
    }

    public void StartGame()
    {
        ChangeGameState(GameState.Active);
        gameTimer = GameTime;
        GameStartEvent.Raise();
    }

    public void EndGame()
    {
        ChangeGameState(GameState.End);
        GameEndEvent.Raise();
    }

    public void PauseGame()
    {
        if (currentState == GameState.Active)
            ChangeGameState(GameState.Pause);
        else if (currentState == GameState.Pause)
            ChangeGameState(GameState.Active);
    }

    void ChangeGameState(GameState gameState)
    {
        if (currentState == gameState) return;
        Debug.Log("Changing to " + gameState.ToString());
        switch (gameState)
        {
            case GameState.Start:
                currentState = GameState.Start;
                return;
            case GameState.Active:
                Time.timeScale = 1;
                GameActiveEvent.Raise();
                currentState = GameState.Active;
                return;
            case GameState.Pause:
                GamePauseEvent.Raise();
                Time.timeScale = 0;
                currentState = GameState.Pause;
                return;
            case GameState.End:
                GameEndEvent.Raise();
                currentState = GameState.End;
                return;
        }

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }

        if (currentState == GameState.Active)
        {
            if (gameTimer >= 0)
            {
                gameTimer -= Time.deltaTime;
            }
            else
            {
                EndGame();
            }
        }
    }
}
