using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BannerBehavior : MonoBehaviour {

    private Text BannerText;
    private GameTimer Timer;
    private void Awake()
    {
        Timer = transform.root.GetComponent<GameTimer>();
        BannerText = transform.GetComponentInChildren<Text>();
    }

    private void Update()
    {
        PrintToBanner(GetDisplayTime(Timer.CurrentTime));
    }

    public void PrintToBanner(string pString)
    {
        BannerText.text = pString;
    }

    public static string GetDisplayTime(float pTimeInSeconds)
    {
        string minutes = Mathf.Floor(pTimeInSeconds / 60).ToString("00");
        string seconds = (pTimeInSeconds % 60).ToString("00");
        return minutes + ":" + seconds;
    }
}
