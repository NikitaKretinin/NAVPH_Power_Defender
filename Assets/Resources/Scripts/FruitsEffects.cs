using System.Collections;
using System.Linq;
using UnityEngine;

public static class FruitsEffects
{
  public static bool ActivateFruitEffect(Effect effect, GameObject player = null, GameObject[] enemies = null)
  {
    switch (effect)
    {
      case Effect.Heal:
        return HealEffect(player);
      case Effect.AttackUp:
        return AttackUpEffect(player);
      case Effect.SpeedUp:
        return SpeedUpEffect(player);
      case Effect.AttackEnemiesDown:
        return AttackEnemiesDownEffect(enemies);
      case Effect.SpeedEnemiesDown:
        return SpeedEnemiesDownEffect(enemies);
      default:
        return false;
    }
  }

  private static bool HealEffect(GameObject player)
  {
    if (player == null) return false;
    var tmp = player.GetComponent<Damageable>();
    Debug.Log(tmp);
    Debug.Log("Heal effect applied");
    tmp.addHealth(10);
    player.GetComponent<Damageable>().addHealth(10);
    return true;
  }
  
  private static bool AttackUpEffect(GameObject player)
  {
    Debug.Log(player);
    if (player == null) return false;
    Damageable component = player.GetComponent<Damageable>();
    if (component.getIsBuffActive()) return false;
    component.StartCoroutine(component.IncreaseDamageCo());
    return true;
  }

  private static bool SpeedUpEffect(GameObject player)
  {
    if (player == null) return false;
    PlayerMovement component = player.GetComponent<PlayerMovement>();
    if (component.getIsBuffActive()) return false;
    component.StartCoroutine(component.IncreaseSpeedCo());
    return true;
  }

  private static bool AttackEnemiesDownEffect(GameObject[] enemies)
  {
    if (enemies == null) return false;
    Debug.Log("AttackEnemiesDown effect applied");
    return true;
  }

  private static bool SpeedEnemiesDownEffect(GameObject[] enemies)
  {
    if (enemies == null) return false;
    Debug.Log("SpeedEnemiesDown effect applied");
    return true;
  }

}