using System.Collections;
using System.Collections.Generic;
using Codetox.Variables;
using UnityEngine;

[System.Serializable]
public class Wave
{
    public int numEnemies;
    public float waveDuration;

    public Wave(int numEnemies, float waveDuration)
    {
        this.numEnemies = numEnemies;
        this.waveDuration = waveDuration;
    }
}

public class WaveManager : MonoBehaviour
{
    public Transform[] groundPoints;
    public Transform[] shootingPoints;
    public Transform[] skyPoints;
    public List<Wave> waves;
    public GameObject[] typesEnemies;
    public GameObject[] spikes;
    public Variable<float> timeIncrease;
    public Variable<int> enemiesIncrease;

    void Awake()
    {
        timeIncrease.Value = 20.0f;
        enemiesIncrease.Value = 5;
        waves.Add(new Wave(5, 30.0f));
    }

    void Update()
    {
        
    }
}
