using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour {

    public int NextSceneIndex;
    public GameEvent FadeOutEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            FadeOutEvent.Raise();
        }
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(NextSceneIndex);
    }
}
