using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventTrigger : MonoBehaviour
{

    public GameEvent gameEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            gameEvent.Raise();
    }
}
