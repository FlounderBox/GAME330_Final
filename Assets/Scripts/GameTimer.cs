using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public GameEvent TimerCompleteEvent;
    public float StartTime = 120f;
    public float CurrentTime
    {
        get
        {
            return timer;
        }
    }
    private float timer;
    private bool isRunning;
    private bool isComplete = false;

    public void StartTimer()
    {
        timer = StartTime;
        isRunning = true;
        isComplete = false;
    }

    public void PauseTimer(bool pPause)
    {
        isRunning = pPause;
    }

    private void Update()
    {
        if (isComplete == false)
        {
            if (isRunning)
            {
                if (timer >= 0)
                    timer -= Time.deltaTime;
                else
                {
                    TimerCompleteEvent.Raise();
                }
            }
        }
    }
}
