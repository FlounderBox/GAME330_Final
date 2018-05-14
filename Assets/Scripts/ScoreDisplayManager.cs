using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreDisplayManager : MonoBehaviour
{
    public ScoreDisplay playerDisplay;
    public ScoreDisplay highestDisplay;

    private HighScore highScore;

    private void Start()
    {
        //DisplayScores();
    }

    public void DisplayScores(float pPlayerScore)
    {
        Debug.Log(pPlayerScore);
        StartCoroutine(DisplayScoreDelay(pPlayerScore));
    }

    IEnumerator DisplayScoreDelay(float pPlayerScore)
    {
        LoadPlayerProgress();
        float prevHighScore = GetHighScore();
        SetNewHighScore(pPlayerScore);
        if (prevHighScore != 0)
        {
            //_playerPercentage = GetHighScore() / GetHighScore() * pPlayerScore + GetHighScore();
            yield return new WaitForSeconds(0.25f);
            if (pPlayerScore > prevHighScore)
                highestDisplay.StartImageAnimation(prevHighScore, pPlayerScore);
            else
                highestDisplay.StartImageAnimation(prevHighScore, prevHighScore);

            yield return new WaitForSeconds(2f);
        }
        else
        {
            highestDisplay.gameObject.SetActive(false);
            playerDisplay.GetComponent<RectTransform>().anchoredPosition = transform.GetComponent<RectTransform>().anchorMax / 2;
        }
        playerDisplay.StartImageAnimation(pPlayerScore, GetHighScore());
    }


    public void SetNewHighScore(float pNewScore)
    {
        if (pNewScore > highScore.CurrentHighScore)
        {
            highScore.CurrentHighScore = pNewScore;
            SavePlayerProgress();
        }
    }

    public float GetHighScore()
    {
        return highScore.CurrentHighScore;
    }

    void LoadPlayerProgress()
    {
        highScore = new HighScore();

        if (PlayerPrefs.HasKey("highScore"))
        {
            highScore.CurrentHighScore = PlayerPrefs.GetFloat("highScore");
        }
    }

    void SavePlayerProgress()
    {
        PlayerPrefs.SetFloat("highScore", highScore.CurrentHighScore);
    }
}
