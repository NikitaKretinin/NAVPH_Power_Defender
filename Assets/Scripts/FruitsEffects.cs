using System.Collections;
using System.Linq;
using UnityEngine;

public static class FruitsEffects
{
  public static bool ActivateFruitEffect(Effect effect, GameObject player = null, GameObject[] enemies = null)
  {
    return effect switch
    {
      Effect.Heal => HealEffect(player),
      Effect.AttackUp => AttackUpEffect(player),
      Effect.SpeedUp => SpeedUpEffect(player),
      Effect.AttackEnemiesDown => AttackEnemiesDownEffect(enemies),
      Effect.SpeedEnemiesDown => SpeedEnemiesDownEffect(enemies),
      _ => false,
    };
  }

  public static string GetEffectDescription(Effect effect)
  {
    return effect switch
    {
      Effect.Heal => "Add 10 health to the player",
      Effect.AttackUp => "Increase the player's attack by 20% for 5 seconds",
      Effect.SpeedUp => "Increase the player's speed by 10% for 5 seconds",
      Effect.AttackEnemiesDown => "Decrease the attack of all enemies by 50% for 5 seconds",
      Effect.SpeedEnemiesDown => "Decrease the speed of all enemies by 50% for 5 seconds",
      _ => "",
    };
  }

  private static bool HealEffect(GameObject player)
  {
    if (player == null) return false;
    var tmp = player.GetComponent<Damageable>();
    Debug.Log(tmp);
    Debug.Log("Heal effect applied");
    tmp.addHealth(10);
    player.GetComponent<Damageable>().addHealth(10);
    Debug.Log("HealEffect effect applied");
    return true;
  }

  private static bool AttackUpEffect(GameObject player)
  {
    Debug.Log(player);
    if (player == null) return false;
    Damageable component = player.GetComponent<Damageable>();
    if (component.getIsBuffActive()) return false;
    component.StartCoroutine(component.IncreaseDamageCo());
    Debug.Log("AttackUpEffect effect applied");
    return true;
  }

  private static bool SpeedUpEffect(GameObject player)
  {
    if (player == null) return false;
    PlayerMovement component = player.GetComponent<PlayerMovement>();
    if (component.getIsBuffActive()) return false;
    component.StartCoroutine(component.IncreaseSpeedCo());
    Debug.Log("SpeedUpEffect effect applied");
    return true;
  }

  private static bool AttackEnemiesDownEffect(GameObject[] enemies)
  {
    if (enemies == null) return false;
    foreach (var enemy in enemies)
    {
      EnemyAttack component = enemy.GetComponent<EnemyAttack>();
      if (!component.getIsBuffActive())
      {
        component.StartCoroutine(component.DecreaseAttackCo());
      }
    }
    Debug.Log("AttackEnemiesDown effect applied");
    return true;
  }

  private static bool SpeedEnemiesDownEffect(GameObject[] enemies)
  {
    if (enemies == null) return false;
    foreach (var enemy in enemies)
    {
      Enemy component = enemy.GetComponent<Enemy>();
      if (!component.getIsBuffActive())
      {
        component.StartCoroutine(component.DecreaseSpeedCo());
      }
    }
    Debug.Log("SpeedEnemiesDown effect applied");
    return true;
  }

}