using System;
using System.Collections;
using System.Collections.Generic;
using Codetox.Variables;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
    public Variable<int> scorePoints;

    private void OnEnable()
    {
        scorePoints.Value = 0;
    }

    public void AddPoints(int points)
    {
        scorePoints.Value += points;
    }
}
