using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    WaveConfiguration waveConfiguration;
    void Awake()
    {
        waveConfiguration = GetComponentInParent<WaveConfiguration>();
    }

    public void SpawnEntity(GameObject entity, bool hasMap)
    {
        // Spawn a new enemy.
        var spawned = Instantiate(entity, transform.position, Quaternion.identity);
        spawned.GetComponent<WaveEnemy>().hasMap = hasMap;
        spawned.SetActive(true);
        waveConfiguration.IncreaseEnemyCount();
    }
}
