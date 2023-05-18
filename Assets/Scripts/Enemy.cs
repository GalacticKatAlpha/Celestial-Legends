using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private float speed = 5f; 

    private WaveSpawner waveSpawner;

    public int health = 50;

    public int value = 50;

    private Transform target;
    private int wavepointIndex = 0;

    private void Start ()
    {
        waveSpawner = GetComponentInParent<WaveSpawner>();
        target = Waypoints.waypoints[0];
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if(health <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        PlayerStats.Money += value;
        Destroy(gameObject);
    }

    void Update ()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoints.waypoints.Length - 1)
        {
            EndPath();
            waveSpawner.waves[waveSpawner.currentWaveIndex].enemiesLeft--;
            return;
        }

        wavepointIndex++;
        target = Waypoints.waypoints[wavepointIndex];
    }

    void EndPath()
    {
        PlayerStats.Health--;
        Destroy(gameObject);
    }

}
