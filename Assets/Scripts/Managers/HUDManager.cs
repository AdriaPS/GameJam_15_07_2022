using System;
using System.Collections;
using System.Collections.Generic;
using Codetox.Variables;
using TMPro;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    public Variable<float> gameTime;
    public TextMeshProUGUI timeText;

    void OnEnable()
    {
        gameTime.OnValueChanged += UpdateScreenValue;
    }

    private void OnDisable()
    {
        gameTime.OnValueChanged -= UpdateScreenValue;
    }

    private void UpdateScreenValue(float obj)
    {
        timeText.text = FormatTime();
    }
    
    public string FormatTime()
    {
        int intTime = (int)gameTime.Value;
        int minutes = intTime / 60;
        int seconds = intTime % 60;
        float milliseconds = gameTime.Value * 1000;
        milliseconds = milliseconds % 1000;
        //return string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
