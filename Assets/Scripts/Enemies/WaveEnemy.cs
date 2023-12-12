using UnityEngine;

public class WaveEnemy : MonoBehaviour
{
  WaveConfiguration waveConfiguration = null;
  [SerializeField] GameObject waveConfigurator;
  [SerializeField] GameObject map;
  public bool hasMap = false;

  void Start()
  {
    waveConfiguration = waveConfigurator.GetComponent<WaveConfiguration>();
  }

  void OnDestroy()
  {
    if (waveConfiguration != null)
    {
      waveConfiguration.DecreaseEnemyCount();

      if (hasMap)
      {
        // Spawn a map.
        var position = transform.position;
        if (map != null)
        {
          Instantiate(map, position, Quaternion.identity).SetActive(true);
        }
      }
    }
  }
}