using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decay : MonoBehaviour
{
    [HideInInspector]
    public float decayTimer;

    public static void AddDecay(GameObject pGameObject, float pLength)
    {
        Decay _decay = pGameObject.AddComponent<Decay>();
        _decay.decayTimer = pLength;
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
