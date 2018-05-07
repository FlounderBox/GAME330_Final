using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decay : MonoBehaviour
{
    private float decayTimer;
    private float decayTime;

    public float StartTime
    {
        get { return decayTime; }
    }

    public float Timer
    {
        get { return decayTimer; }
    }

    public static void AddDecay(GameObject pGameObject, float pLength)
    {
        Decay _decay = pGameObject.AddComponent<Decay>();
        _decay.decayTime = pLength;
        _decay.decayTimer = pLength;
    }

    private void Awake()
    {
        decayTime = decayTimer;
    }

    private void Update()
    {
        if (decayTimer >= 0)
        {
            decayTimer -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
