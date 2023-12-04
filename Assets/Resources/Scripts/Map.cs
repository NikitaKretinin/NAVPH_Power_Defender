using UnityEngine;

public class Map : MonoBehaviour
{
  [SerializeField] GameObject player;
  [SerializeField] GameObject waveConfigurator;
  private WaveConfiguration waveConfiguration = null;

  private void Start()
  {
    waveConfiguration = waveConfigurator.GetComponent<WaveConfiguration>();
  }

  void Update()
  {
    // If the player is close enough to the map, destroy it.
    if (Input.GetButtonDown("collect"))
    {
      CollectMap();
    }
  }

  void CollectMap()
  {
    if (Vector2.Distance(transform.position, player.transform.position) < 1.5f)
    {
      Debug.Log("Map collected!");
      Destroy(gameObject);
      waveConfiguration.mapCollected = true;

      // TODO: Save to global inventory after levels have been implemented.
    }
  }
}