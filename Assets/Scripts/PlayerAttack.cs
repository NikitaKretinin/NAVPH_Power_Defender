using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private int damageAmount; // Adjust the damage amount as needed.
    [SerializeField] GameObject player; // related player
    bool triggered = false;
    Damageable enemyDamageable = null;

    void Start()
    {
        damageAmount = player.GetComponent<Damageable>().getDamage();
    }

    void Update()
    {
        damageAmount = player.GetComponent<Damageable>().getDamage();

        var attackPressed = Input.GetButtonDown("attack");

        if (attackPressed && triggered)
        {
            Debug.Log(enemyDamageable);
            // If the enemy has a Damageable component, apply damage to it.
            if (enemyDamageable != null)
            {
                enemyDamageable.TakeDamage(damageAmount);
            }
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        // Check if the collision is with an object tagged as "Enemy."
        triggered = collision.gameObject.CompareTag("EnemyAttackCollider");
        if (triggered)
        {
            // Get the Damageable script component from the collided enemy.
            enemyDamageable = collision.gameObject.transform.parent.GetComponent<Damageable>();
        }
    }
}
