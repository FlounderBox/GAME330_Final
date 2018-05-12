using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonMenu : MonoBehaviour
{

    public delegate void SimonButton();
    static SimonButton RedButton;
    static SimonButton YellowButton;
    static SimonButton BlueButton;
    static SimonButton GreenButton;

    private void Update()
    {

        if (SimonXInterface.GetButtonDown(SimonXInterface.SimonButtonType.Button_UL))
        {
            if (BlueButton != null)
                BlueButton.Invoke();
            else
                Debug.LogError("BlueButton is null");
            return;
        }
        if (SimonXInterface.GetButtonDown(SimonXInterface.SimonButtonType.Button_UR))
        {
            if (YellowButton != null)
                YellowButton.Invoke();
            else
                Debug.LogError("YellowButton is null");
            return;
        }
        if (SimonXInterface.GetButtonDown(SimonXInterface.SimonButtonType.Button_LR))
        {
            if (RedButton != null)
                RedButton.Invoke();
            else
                Debug.LogError("RedButton is null");
            return;
        }
        if (SimonXInterface.GetButtonDown(SimonXInterface.SimonButtonType.Button_LL))
        {
            if (GreenButton != null)
                GreenButton.Invoke();
            else
                Debug.LogError("GreenButton is null");
            return;
        }
    }

    public static void SetSimonButtonMethod(SimonXInterface.SimonButtonType pButton, SimonButton pFunction)
    {
        switch (pButton)
        {
            case SimonXInterface.SimonButtonType.Button_UL:
                BlueButton = pFunction;
                break;

            case SimonXInterface.SimonButtonType.Button_UR:
                YellowButton = pFunction;
                break;

            case SimonXInterface.SimonButtonType.Button_LR:
                RedButton = pFunction;
                break;

            case SimonXInterface.SimonButtonType.Button_LL:
                GreenButton = pFunction;
                break;
        }
    }

    public static void ClearSimonButtons()
    {
        RedButton = null;
        BlueButton = null;
        GreenButton = null;
        YellowButton = null;
    }
}
