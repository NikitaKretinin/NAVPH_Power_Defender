using UnityEngine;

public class WaveEnemy : MonoBehaviour
{
  private WaveConfiguration waveConfiguration = null;
  [SerializeField] GameObject waveConfigurator = null;
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
      Debug.Log("Enemy map? " + hasMap);
    }
  }
}