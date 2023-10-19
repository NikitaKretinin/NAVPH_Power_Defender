using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] int damageAmount = 10; // Adjust the damage amount as needed.
    [SerializeField] float attackSpeed = 1.0f; // The time between consecutive attacks in seconds.
    private float lastAttackTime = 0.0f; // The time of the last attack.

    private void OnCollisionStay2D(Collision2D collision)
    {
        // Check if the collision is with an object tagged as "Player."
        if ((collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Base")) && Time.time - lastAttackTime >= attackSpeed)
        {
            Debug.Log("<color=red>Collision with player or base happened!</color>");
            // Get the Damageable script component from the collided enemy.
            Damageable enemyDamageable = collision.gameObject.GetComponent<Damageable>();

            // If the enemy has a Damageable component, apply damage to it.
            if (enemyDamageable != null)
            {
                enemyDamageable.TakeDamage(damageAmount);

                // Update the time of the last attack.
                lastAttackTime = Time.time;
            }
        }
    }
}
