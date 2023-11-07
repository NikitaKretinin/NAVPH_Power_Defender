using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    WaveConfiguration waveConfiguration;
    void Awake()
    {
        waveConfiguration = GetComponentInParent<WaveConfiguration>();
    }

    public void SpawnEntity(GameObject entity)
    {
        // Spawn a new enemy.
        Instantiate(entity, transform.position, Quaternion.identity).SetActive(true);
        waveConfiguration.IncreaseEnemyCount();
    }

    // // Update is called once per frame
    // void FixedUpdate()
    // {
    //     if (Time.time - lastSpawnTime >= spawnDelay)
    //     {
    //         // Spawn a new enemy.
    //         Instantiate(enemySpawned, transform.position, Quaternion.identity).SetActive(true);

    //         // Update the time of the last spawn.
    //         lastSpawnTime = Time.time;
    //     }
    // }
}
