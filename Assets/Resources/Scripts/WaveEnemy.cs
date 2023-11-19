using UnityEngine;

public class WaveEnemy : MonoBehaviour
{
  private WaveConfiguration waveConfiguration = null;

  private void Start()
  {
    waveConfiguration = GameObject.Find("WaveConfigurator").GetComponent<WaveConfiguration>();
  }

  private void OnDestroy()
  {
    Debug.Log("waveConfiguration: " + waveConfiguration);
    if (waveConfiguration != null)
    {
      Debug.Log("enemy killed");
      waveConfiguration.DecreaseEnemyCount();
    }
  }
}