using System;
using System.Collections;
using System.Collections.Generic;
using Codetox.Variables;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
    public Variable<int> scorePoints;

    public void AddPoints(int points)
    {
        scorePoints.Value += points;
    }
}
