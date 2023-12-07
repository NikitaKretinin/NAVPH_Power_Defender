using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private int damageAmount = 10; // Adjust the damage amount as needed.
    [SerializeField] GameObject player; // related player

    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        damageAmount = player.GetComponent<Damageable>().getDamage();
    }

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
}
