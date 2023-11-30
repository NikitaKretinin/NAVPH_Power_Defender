using System.Collections;
using System.Linq;
using UnityEngine;

public static class FruitsEffects
{
  public static void ActivateFruitEffect(Effect effect, GameObject player = null, GameObject[] enemies = null)
  {
    switch (effect)
    {
      case Effect.Heal:
        HealEffect(player);
        break;
      case Effect.AttackUp:
        AttackUpEffect(player);
        break;
      case Effect.SpeedUp:
        SpeedUpEffect(player);
        break;
      case Effect.AttackEnemiesDown:
        AttackEnemiesDownEffect(enemies);
        break;
      case Effect.SpeedEnemiesDown:
        SpeedEnemiesDownEffect(enemies);
        break;
      default:
        break;
    }
  }

  private static void HealEffect(GameObject player)
  {
    if (player == null) return;
    var tmp = player.GetComponent<Damageable>();
    Debug.Log(tmp);
    Debug.Log("Heal effect applied");
    tmp.addHealth(10);
    player.GetComponent<Damageable>().addHealth(10);
  }
  
  private static void AttackUpEffect(GameObject player)
  {
    Debug.Log(player);
    if (player == null) return;
    Damageable component = player.GetComponent<Damageable>();
    component.StartCoroutine(component.IncreaseDamageCo());
  }

  private static void SpeedUpEffect(GameObject player)
  {
    if (player == null) return;
    Debug.Log("SpeedUp effect applied");
  }

  private static void AttackEnemiesDownEffect(GameObject[] enemies)
  {
    if (enemies == null) return;
    Debug.Log("AttackEnemiesDown effect applied");
  }

  private static void SpeedEnemiesDownEffect(GameObject[] enemies)
  {
    if (enemies == null) return;
    Debug.Log("SpeedEnemiesDown effect applied");
  }

}