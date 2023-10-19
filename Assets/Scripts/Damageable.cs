using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        // Check if the GameObject is dead.
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (gameObject.CompareTag("Player") || gameObject.CompareTag("Base"))
        {
            // If the GameObject is the player, end the game.
            Debug.Log("Game Over!");
        }
        else
        {
            // If the GameObject is an enemy, destroy it.
            Destroy(gameObject);
        }
    }
}
