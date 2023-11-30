using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] int damageAmount = 10; // Adjust the damage amount as needed.

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with an object tagged as "Enemy."
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Get the Damageable script component from the collided enemy.
            Damageable enemyDamageable = collision.gameObject.GetComponent<Damageable>();
            Debug.Log(enemyDamageable);
            // If the enemy has a Damageable component, apply damage to it.
            if (enemyDamageable != null)
            {
                enemyDamageable.TakeDamage(damageAmount);
            }
        }
    }
    
    private static void HealEffect(GameObject player)
    {
        if (player == null) return;
        player.GetComponent<Damageable>().addHealth(10);
    }
  
    public IEnumerator IncreaseDamageCo()
    {
        int prevDamage = damageAmount;
        damageAmount = (int)(prevDamage * 1.2f);
        yield return new WaitForSeconds(5.0f);
        damageAmount = prevDamage;
    }
}
