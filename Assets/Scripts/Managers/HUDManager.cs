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
        int minutes = (int) gameTime.Value / 60 / 60 ;
        int seconds = (int) gameTime.Value / 60;
        int milliseconds = (int) gameTime.Value;
        return string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds );
    }
}
