using System.Collections;
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
    player.GetComponent<Damageable>().addHealth(10);
  }
  
  private static void AttackUpEffect(GameObject player)
  {
    if (player == null) return;
    var hitboxes = player.GetComponentsInChildren<PlayerAttack>();
    foreach (var hitbox in hitboxes)
    {
      hitbox.StartCoroutine(hitbox.IncreaseDamageCo());
    }
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