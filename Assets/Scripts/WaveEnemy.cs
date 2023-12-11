using UnityEngine;

public class WaveEnemy : MonoBehaviour
{
  private WaveConfiguration waveConfiguration = null;
  [SerializeField] GameObject waveConfigurator;
  [SerializeField] GameObject map;
  public bool hasMap = false;

  private void Start()
  {
    waveConfiguration = waveConfigurator.GetComponent<WaveConfiguration>();
  }

  private void OnDestroy()
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