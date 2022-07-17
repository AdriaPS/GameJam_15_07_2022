using System.Collections;
using System.Collections.Generic;
using Codetox.Variables;
using UnityEngine;

[System.Serializable]
public class Wave
{
    public int numEnemies;
    public float waveDuration;
}

public class WaveManager : MonoBehaviour
{
    public Transform[] groundPoints;
    public Transform[] skyPoints;
    public Wave[] waves;
    public GameObject[] typesEnemies;
    public Variable<float> timeIncrease;
    public Variable<int> enemiesIncrease;

    void Awake()
    {
        timeIncrease.Value = 20.0f;
        enemiesIncrease.Value = 5;
    }

    void Update()
    {
        
    }
}
