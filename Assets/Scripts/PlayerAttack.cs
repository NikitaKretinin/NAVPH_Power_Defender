using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private int damageAmount; // Adjust the damage amount as needed.
    [SerializeField] GameObject player; // related player

    void Start()
    {
        damageAmount = player.GetComponent<Damageable>().getDamage();
    }

    void Update()
    {
        damageAmount = player.GetComponent<Damageable>().getDamage();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collision is with an object tagged as "Enemy."
        if (collision.gameObject.CompareTag("EnemyAttackCollider"))
        {
            // Get the Damageable script component from the collided enemy.
            Damageable enemyDamageable = collision.gameObject.transform.parent.GetComponent<Damageable>();
            // If the enemy has a Damageable component, apply damage to it.
            if (enemyDamageable != null)
            {
                enemyDamageable.TakeDamage(damageAmount);
            }
        }
    }
}
