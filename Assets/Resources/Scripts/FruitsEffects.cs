using UnityEngine;

public static class FruitsEffects
{
  public static void ActivateFruitEffect(Effect effect)
  {
    switch (effect)
    {
      case Effect.Heal:
        HealEffect();
        break;
      case Effect.AttackUp:
        AttackUpEffect();
        break;
      case Effect.SpeedUp:
        SpeedUpEffect();
        break;
      case Effect.AttackEnemiesDown:
        AttackEnemiesDownEffect();
        break;
      case Effect.SpeedEnemiesDown:
        SpeedEnemiesDownEffect();
        break;
      default:
        break;
    }
  }

  private static void HealEffect()
  {
    Debug.Log("Heal effect applied");
  }

  private static void AttackUpEffect()
  {
    Debug.Log("AttackUp effect applied");
  }

  private static void SpeedUpEffect()
  {
    Debug.Log("SpeedUp effect applied");
  }

  private static void AttackEnemiesDownEffect()
  {
    Debug.Log("AttackEnemiesDown effect applied");
  }

  private static void SpeedEnemiesDownEffect()
  {
    Debug.Log("SpeedEnemiesDown effect applied");
  }

}