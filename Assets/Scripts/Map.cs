using UnityEngine;

public class Map : MonoBehaviour
{
  [SerializeField] GameObject player;
  [SerializeField] GameObject waveConfigurator;
  WaveConfiguration waveConfiguration = null;

  void Start()
  {
    waveConfiguration = waveConfigurator.GetComponent<WaveConfiguration>();
  }

  void Update()
  {
    if (Input.GetButtonDown("collect"))
    {
      // If the player is close enough to the map, destroy it.
      CollectMap();
    }
  }

  void CollectMap()
  {
    if (Vector2.Distance(transform.position, player.transform.position) < 1.5f)
    {
      Destroy(gameObject);
      waveConfiguration.mapCollected = true;
    }
  }
}