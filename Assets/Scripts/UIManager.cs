using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public Text TimerText;

    private void Update()
    {
        string minutes = Mathf.Floor(GameManager.GameTimer / 60).ToString("00");
        string seconds = (GameManager.GameTimer % 60).ToString("00");
        TimerText.text = minutes + ":" + seconds;
    }
}
