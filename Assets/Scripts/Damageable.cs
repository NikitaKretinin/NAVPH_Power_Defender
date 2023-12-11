using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Damageable : MonoBehaviour
{
    bool isBuffActive = false;
    [SerializeField] int maxHealth;
    [SerializeField] int currentHealth;
    [SerializeField] int damageAmount; // Adjust the damage amount as needed.

    float statsCoef = 1.0f; // Adjust the stats coefficient for enemies.

    void Start()
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

    void Die()
    {
        GameObject map = null;

        if (InterScene.gameMode == GameMode.Defense)
        {
            map = GameObject.FindWithTag("Map");
        }

        if (gameObject.CompareTag("Player") || gameObject.CompareTag("Base"))
        {
            if (map != null)
            {
                Destroy(map);
            }
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
