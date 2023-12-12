using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    int damageAmount; // Adjust the damage amount as needed.
    [SerializeField] GameObject player; // related player
    bool triggered = false;
    Damageable enemyDamageable = null;

    void Start()
    {
        damageAmount = player.GetComponent<Damageable>().GetDamage();
    }

    void Update()
    {
        damageAmount = player.GetComponent<Damageable>().GetDamage();

        var attackPressed = Input.GetButtonDown("attack");

        if (attackPressed && triggered)
        {
            // If the enemy has a Damageable component, apply damage to it.
            if (enemyDamageable != null)
            {
                enemyDamageable.TakeDamage(damageAmount);
            }
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        triggered = collision.gameObject.CompareTag("EnemyDamageableCollider");
        if (triggered)
        {
            // Get the Damageable script component from the collided enemy.
            enemyDamageable = collision.gameObject.transform.parent.GetComponent<Damageable>();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        var parent = other.transform.parent;

        if (parent == null)
        {
            return;
        }

        var damageable = parent.GetComponent<Damageable>();
        if (enemyDamageable != null && enemyDamageable.Equals(damageable))
        {
            triggered = false;
        }
    }
}
