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
    public Variable<int> scorePoints;
    public TextMeshProUGUI scoreText;
    public Variable<int> waveCount;
    public TextMeshProUGUI waveCountText;

    void OnEnable()
    {
        gameTime.OnValueChanged += UpdateScreenValue;
        scorePoints.OnValueChanged += UpdateScreenValueInt;
        waveCount.OnValueChanged += UpdateScreenValueInt;
        scoreText.text = "Score: " + scorePoints.Value;
        waveCountText.text = "Wave: " + waveCount.Value;
    }

    private void OnDisable()
    {
        gameTime.OnValueChanged -= UpdateScreenValue;
        scorePoints.OnValueChanged -= UpdateScreenValueInt;
        waveCount.OnValueChanged -= UpdateScreenValueInt;
    }

    private void UpdateScreenValue(float obj)
    {
        timeText.text = FormatTime();
    }
    
    private void UpdateScreenValueInt(int obj)
    {
        scoreText.text = "Score: " + scorePoints.Value;
        waveCountText.text = "Wave: " + waveCount.Value;
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
