using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameEvent FadeInEvent;
    public GameEvent FadeOutEvent;
    public GameEvent GameInitEvent;
    public GameEvent GameStartEvent;
    public GameEvent GameEndEvent;
    public GameEvent GamePauseEvent;
    public GameEvent GameActiveEvent;
    public GameEvent CleanupEvent;

    public int[] SceneIndexes;

    public enum GameState
    {
        None,
        Init,
        Start,
        Active,
        Pause,
        End
    }

    GameState currentState = GameState.None;


    private void Start()
    {
        ChangeGameState(GameState.Init);
    }

    public void StartGame()
    {
        GameStartEvent.Raise();
        ChangeGameState(GameState.Active);
    }

    public void EndGame()
    {
        ChangeGameState(GameState.End);
    }

    public void PauseGame()
    {
        if (currentState != GameState.Pause)
            ChangeGameState(GameState.Pause);
        else if (currentState == GameState.Pause)
            ChangeGameState(GameState.Active);
    }
    public void PauseGame(bool bPause)
    {
        if (bPause)
            ChangeGameState(GameState.Pause);
        else
            ChangeGameState(GameState.Active);
    }

    void LoadAttic()
    {
        SimonMenu.ClearSimonButtons();
        StartCoroutine(WaitUntilTimeResume(FadeOutEvent.Raise));
    }
   

    void ReloadScene()
    {
        SimonMenu.ClearSimonButtons();
        StartCoroutine(WaitUntilTimeResume(FadeOutEvent.Raise));
    }
    IEnumerator WaitUntilTimeResume(SimonMenu.SimonButton pMethod)
    {
        Time.timeScale = 1;
        yield return new WaitUntil(() => Time.deltaTime > 0f);
        pMethod.Invoke();
    }

    void ChangeGameState(GameState gameState)
    {
        if (currentState == gameState) return;
        //Debug.Log("Changing to " + gameState.ToString());
        switch (gameState)
        {
            case GameState.Init:
                SimonMenu.ClearSimonButtons();
                GameInitEvent.Raise();
                currentState = GameState.Init;
                return;
            case GameState.Start:
                GameStartEvent.Raise();
                currentState = GameState.Start;
                return;
            case GameState.Active:
                SimonMenu.ClearSimonButtons();
                SimonMenu.SetSimonButtonMethod(SimonXInterface.SimonButtonType.Button_UL, PauseGame);
                SimonMenu.SetSimonButtonMethod(SimonXInterface.SimonButtonType.Button_UR, PauseGame);
                SimonMenu.SetSimonButtonMethod(SimonXInterface.SimonButtonType.Button_LR, PauseGame);
                SimonMenu.SetSimonButtonMethod(SimonXInterface.SimonButtonType.Button_LL, PauseGame);
                Time.timeScale = 1;
                GameActiveEvent.Raise();
                currentState = GameState.Active;
                return;
            case GameState.Pause:
                SimonMenu.ClearSimonButtons();
                SimonMenu.SetSimonButtonMethod(SimonXInterface.SimonButtonType.Button_UL, PauseGame);
                SimonMenu.SetSimonButtonMethod(SimonXInterface.SimonButtonType.Button_UR, LoadAttic);
                SimonMenu.SetSimonButtonMethod(SimonXInterface.SimonButtonType.Button_LR, ReloadScene);
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
    }
}
