using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private float countdown;

    public Wave[] waves;

    private int currentWaveIndex = 0;

    private void Update()
    {
        countdown -= Time.deltaTime;

        if (countdown <= 0)
        {
            SpawnWave();
        }
    }

    private void SpawnWave()
    {
        
    }

}

[System.Serializable]
public class Wave
{
    public Enemy[] enemies;
}


