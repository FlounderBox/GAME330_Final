using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTracker : MonoBehaviour {

    public GameEvent SendScoreEvent;
    public float score
    {
        get
        {
            return GetComponentInParent<JellyController>().Score;
        }
    }

    public void SendScore()
    {
        SendScoreEvent.Raise(score);
    }
}

