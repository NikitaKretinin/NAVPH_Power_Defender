using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    private bool isBuffActive = false;
    [SerializeField] private int maxHealth = 100;
    [SerializeField] int currentHealth;
    [SerializeField] private int damageAmount = 0; // Adjust the damage amount as needed.

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

    public int getHealth()
    {
        return currentHealth;
    }

    public void addHealth(int healthToAdd)
    {
        if (currentHealth + healthToAdd > maxHealth)
            currentHealth = maxHealth;
        else
            currentHealth += healthToAdd;
    }
    
    public int getMaxHealth()
    {
        return maxHealth;
    }

    public int getDamage()
    {
        return damageAmount;
    }

    public bool getIsBuffActive()
    {
        return isBuffActive;
    }
    
    public IEnumerator IncreaseDamageCo()
    {
        int prevDamage = damageAmount;
        damageAmount = (int)(prevDamage * 1.2f);
        isBuffActive = true;
        yield return new WaitForSeconds(5.0f);
        isBuffActive = false;
        damageAmount = prevDamage;
        yield return null;
    }
}
