using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private int damageAmount; // Adjust the damage amount as needed.
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
}
