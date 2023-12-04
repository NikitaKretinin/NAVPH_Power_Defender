using UnityEngine;
using UnityEngine.SceneManagement;

public class WaveConfiguration : MonoBehaviour
{
    [SerializeField] GameObject[] spawners;
    [SerializeField] GameObject firstWaveEnemy;
    [SerializeField] int firstWaveEnemyCount;
    [SerializeField] GameObject secondWaveEnemy;
    [SerializeField] int secondWaveEnemyCount;
    [SerializeField] GameObject thirdWaveEnemy;
    [SerializeField] int thirdWaveEnemyCount;
    [SerializeField] float spawnDelay;
    float lastSpawnTime = 0.0f; // The time since the last spawn.
    public int enemiesSpawned = 0;
    public int enemiesKilled = 0;
    bool firstWavePassed = false;
    bool secondWavePassed = false;
    bool thirdWavePassed = false;
    public bool mapCollected = false;
    int randomWave;

    void Awake()
    {
        // Get child spawner objects.
        spawners = GameObject.FindGameObjectsWithTag("Spawner");
    }

    void Start()
    {
        randomWave = Random.Range(0, 3);
    }

    void FixedUpdate()
    {
        if (!firstWavePassed)
        {
            SpawnAndControlEnemies(0, firstWaveEnemy, firstWaveEnemyCount, ref firstWavePassed);
        }
        else if (!secondWavePassed)
        {
            SpawnAndControlEnemies(1, secondWaveEnemy, secondWaveEnemyCount, ref secondWavePassed);
        }
        else if (!thirdWavePassed)
        {
            SpawnAndControlEnemies(2, thirdWaveEnemy, thirdWaveEnemyCount, ref thirdWavePassed);
        }
        else if (mapCollected)
        {
            SceneManager.LoadScene("VictoryScreen");
        }
    }

    private void SpawnAndControlEnemies(int waveIndex, GameObject enemy, int count, ref bool wavePassed)
    {
        int enemyNumThatHasMap = Random.Range(0, count);

        if (enemiesSpawned < count)
        {
            if (Time.time - lastSpawnTime >= spawnDelay)
            {
                if (enemiesSpawned == enemyNumThatHasMap && waveIndex == randomWave)
                {
                    spawners[Random.Range(0, spawners.Length)].GetComponent<EnemySpawner>().SpawnEntity(enemy, true);
                    Debug.Log("Enemy with map spawned!");
                }
                else
                {
                    spawners[Random.Range(0, spawners.Length)].GetComponent<EnemySpawner>().SpawnEntity(enemy, false);
                }
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
