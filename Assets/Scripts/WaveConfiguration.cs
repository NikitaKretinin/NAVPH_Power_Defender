using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveConfiguration : MonoBehaviour
{
    [SerializeField] GameObject[] spawners;
    [SerializeField] GameObject firstWaveEnemy;

    [SerializeField] int firstWaveEnemyCount = 0;

    [SerializeField] GameObject secondWaveEnemy;

    [SerializeField] int secondWaveEnemyCount = 0;

    [SerializeField] GameObject thirdWaveEnemy;

    [SerializeField] int thirdWaveEnemyCount = 0;

    [SerializeField] float spawnDelay = 5f;
    private float lastSpawnTime = 0.0f; // The time since the last spawn.

    public int enemiesSpawned = 0;
    public int enemiesKilled = 0;
    private bool firstWavePassed = false;
    private bool secondWavePassed = false;
    private bool thirdWavePassed = false;

    void Awake()
    {
        // Get child spawner objects.
        spawners = GameObject.FindGameObjectsWithTag("Spawner");
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        if (!firstWavePassed)
        {
            Debug.Log("First wave not passed!");
            spawnAndControlEnemies(firstWaveEnemy, firstWaveEnemyCount, ref firstWavePassed);
        }
        else if (!secondWavePassed)
        {
            Debug.Log("Second wave not passed!");
            spawnAndControlEnemies(secondWaveEnemy, secondWaveEnemyCount, ref secondWavePassed);
        }
        else if (!thirdWavePassed)
        {
            Debug.Log("Third wave not passed!");
            spawnAndControlEnemies(thirdWaveEnemy, thirdWaveEnemyCount, ref thirdWavePassed);
        }
        else
        {
            Debug.Log("All waves passed!");
        }
    }

    private void spawnAndControlEnemies(GameObject enemy, int count, ref bool wavePassed)
    {
        if (enemiesSpawned < count)
        {
            if (Time.time - lastSpawnTime >= spawnDelay)
            {
                spawners[Random.Range(0, spawners.Length)].GetComponent<EnemySpawner>().SpawnEntity(enemy);
                lastSpawnTime = Time.time;
            }
        }
        else if (enemiesKilled >= count)
        {
            wavePassed = true;
            enemiesSpawned = 0;
            enemiesKilled = 0;
        }
    }

    public void DecreaseEnemyCount()
    {
        enemiesKilled++;
    }

    public void IncreaseEnemyCount()
    {
        enemiesSpawned++;
    }
}
