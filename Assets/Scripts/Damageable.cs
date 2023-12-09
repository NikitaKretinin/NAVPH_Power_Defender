using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Damageable : MonoBehaviour
{
    private bool isBuffActive = false;
    [SerializeField] private int maxHealth = 100;
    [SerializeField] int currentHealth;
    [SerializeField] private int damageAmount = 0; // Adjust the damage amount as needed.

    private float statsCoef = 1.0f; // Adjust the stats coefficient for enemies.

    private void Start()
    {
        // Adjust the stats using coefficient for enemies.
        maxHealth = (int)(maxHealth * statsCoef);
        damageAmount = (int)(damageAmount * statsCoef); 
        currentHealth = maxHealth;
    }

    public void SetCoefficient(float coef)
    {
        statsCoef = coef;
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
            SceneManager.LoadScene("DefeatScreen");
        }
        else
        {
            // If the GameObject is an enemy, destroy it.
            Destroy(gameObject);
        }
    }

    public int GetHealth()
    {
        return currentHealth;
    }

    public void AddHealth(int healthToAdd)
    {
        if (currentHealth + healthToAdd > maxHealth)
            currentHealth = maxHealth;
        else
            currentHealth += healthToAdd;
    }
    
    public int GetMaxHealth()
    {
        return maxHealth;
    }

    public int GetDamage()
    {
        return damageAmount;
    }

    public void SetDamage(int newDamage)
    {
        damageAmount = newDamage;
    }
    
    public bool GetIsBuffActive()
    {
        return isBuffActive;
    }
    
    // Coroutine to increase damage for 5 seconds
    public IEnumerator IncreaseDamageCo()
    {
        int prevDamage = damageAmount;
        damageAmount = (int)(prevDamage * 1.5f);
        isBuffActive = true;
        yield return new WaitForSeconds(5.0f);
        isBuffActive = false;
        damageAmount = prevDamage;
        yield return null;
    }
}
