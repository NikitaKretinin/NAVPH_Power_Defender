using UnityEngine;
using UnityEngine.SceneManagement;

public class WaveConfiguration : MonoBehaviour
{
    [SerializeField] GameObject[] spawners;
    [SerializeField] float spawnDelay;
    [SerializeField] GameObject[] waveEnemies;
    [SerializeField] int[] waveEnemyCounts;
    [SerializeField] bool[] wavePassed;
    int currentWave = 0;
    float lastSpawnTime = 0.0f; // The time since the last spawn.
    public int enemiesSpawned = 0;
    public int enemiesKilled = 0;
    public bool mapCollected = false;
    int randomWave;
    int randomEnemy;

    void Awake()
    {
        // Get child spawner objects.
        spawners = GameObject.FindGameObjectsWithTag("Spawner");
    }

    void Start()
    {
        randomWave = Random.Range(0, 3);
        randomEnemy = Random.Range(0, waveEnemyCounts[randomWave]);
    }

    void FixedUpdate()
    {
        if (currentWave < waveEnemies.Length && !wavePassed[currentWave])
        {
            SpawnAndControlEnemies();
        }
        else if (mapCollected)
        {
            GlobalInventoryManager.AddMap();
            GlobalInventoryManager.SwitchToNextDefenseLevel();
            SceneManager.LoadScene(InterScene.VICTORY_SCREEN);
        }
    }

    private void SpawnAndControlEnemies()
    {
        if (enemiesSpawned < waveEnemyCounts[currentWave])
        {
            if (Time.time - lastSpawnTime >= spawnDelay)
            {
                var spawnWithMap = enemiesSpawned == randomEnemy && currentWave == randomWave;
                spawners[Random.Range(0, spawners.Length)].GetComponent<EnemySpawner>().SpawnEntity(waveEnemies[currentWave], spawnWithMap);
                lastSpawnTime = Time.time;
            }
        }
        else if (enemiesKilled >= waveEnemyCounts[currentWave])
        {
            wavePassed[currentWave] = true;
            enemiesSpawned = 0;
            enemiesKilled = 0;
            currentWave++;
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
