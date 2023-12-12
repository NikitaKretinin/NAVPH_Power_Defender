using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] GameObject player; // related player
    bool triggered = false;
    Damageable enemyDamageable = null;

    void Update()
    {
        var attackPressed = Input.GetButtonDown("attack");

        if (attackPressed && triggered)
        {
            // If the enemy has a Damageable component, apply damage to it.
            if (enemyDamageable != null)
            {
                var damage = player.GetComponent<Damageable>().GetDamage();
                enemyDamageable.TakeDamage(damage);
            }
        }
    }

    // Check if the player is in range to attack the enemy. The enemy has a trigger collider on its sub-object.
    void OnTriggerStay2D(Collider2D collision)
    {
        triggered = collision.gameObject.CompareTag("EnemyDamageableCollider");
        if (triggered)
        {
            // Get the Damageable script component from the collided enemy.
            enemyDamageable = collision.gameObject.transform.parent.GetComponent<Damageable>();
        }
    }

    // Check if the player is no longer in range to attack the enemy.
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
