using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour {

    public void ChangeScene(float pBuildIndex)
    {
        int intIndex = Mathf.CeilToInt(pBuildIndex);
        Time.timeScale = 1;
        if (SceneManager.GetSceneAt(intIndex) == null)
        {
            Debug.LogError("Build index" + pBuildIndex + " is invalid.");
            return;
        }
        SceneManager.LoadScene(intIndex);
        return;
    }

    public void ReloadScene()
    {
        ChangeScene(SceneManager.GetActiveScene().buildIndex);
    }

    public static int GetCurrentScene()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }
}
