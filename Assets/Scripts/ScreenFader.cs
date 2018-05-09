using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenFader : MonoBehaviour {

    public GameEvent FadedInEvent;
    public GameEvent FadedOutEvent;

    public Material fadeMaterial;

    bool fadeIn = true;
    bool fadeComplete = false;
    private float currentFade = 0;
    private float fadeAmount = 0;

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, fadeMaterial);
    }

    private void Start()
    {
        FadeIn(3);
    }

    public void FadeIn(int pSeconds)
    {
        fadeAmount = 1f / pSeconds * Time.deltaTime;
        Debug.Log(Time.deltaTime);
        currentFade = 0f;
        fadeIn = true;
        fadeComplete = false;
    }

    public void FadeOut(int pSeconds)
    {
        fadeAmount = 1f / pSeconds * Time.deltaTime;
        currentFade = 1f;
        fadeIn = false;
        fadeComplete = false;
    }

    private void Update()
    {
        if (fadeComplete == false)
        {
            if (fadeIn)
            {
                currentFade += fadeAmount;
                if (currentFade >= 1)
                {
                    FadedInEvent.Raise();
                    fadeComplete = true;
                }
            }
            else
            {
                currentFade -= fadeAmount;
                if (currentFade <= 0)
                {
                    FadedOutEvent.Raise();
                    fadeComplete = true;
                }
            }
            fadeMaterial.SetFloat("_Cutoff", currentFade);
        }
    }
}
