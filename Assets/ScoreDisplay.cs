using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore
{
    public float CurrentHighScore;
}

public class ScoreDisplay : MonoBehaviour
{
    public string DisplayText = "Score: ";
    Image sizeImage;
    Text textScore;

    Vector2 startingImageSize;
    bool animationPlaying = false;
    float scalePercentage;

    float scoreMax;

    private void Awake()
    {
        sizeImage = transform.Find("Image").GetComponent<Image>();
        textScore = transform.Find("Text").GetComponent<Text>();

        startingImageSize = sizeImage.rectTransform.localScale;
        sizeImage.rectTransform.localScale = Vector2.zero;
        textScore.text = "";
    }

    public void StartImageAnimation(float pScore, float pScoreMax)
    {
        float _scorePercentage = (pScore) / (pScoreMax);
        scoreMax = pScoreMax;
        Debug.Log(_scorePercentage);
        sizeImage.rectTransform.localScale = Vector2.zero;
        scalePercentage = _scorePercentage;
        textScore.text = "";
        animationPlaying = true;
    }

    public void SetDisplayText(string pDisplayText)
    {
        textScore.text = pDisplayText;
    }

    void PlayImageAnimation()
    {
        Vector2 _scale = sizeImage.rectTransform.localScale;
        sizeImage.rectTransform.localScale = Vector2.Lerp(_scale, startingImageSize * scalePercentage, Time.deltaTime);
        textScore.text = DisplayText + "\n" + (Mathf.RoundToInt(Mathf.Lerp(0, scoreMax, Mathf.Lerp(sizeImage.rectTransform.localScale.x, scoreMax, Time.deltaTime)) * 1000f)).ToString();
    }

    private void Update()
    {
        if (animationPlaying)
        {
            PlayImageAnimation();
        }
    }

}