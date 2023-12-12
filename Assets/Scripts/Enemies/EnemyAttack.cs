using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    bool isBuffActive = false;
    [SerializeField] float attackSpeed = 1.0f; // The time between consecutive attacks in seconds.
    [SerializeField] Enemy thisEnemy; // Reference to the Enemy script component on this object.
    float lastAttackTime = 0.0f; // The time of the last attack.

    // Start is called before the first frame update
    void Start()
    {
        // Get the Enemy script component from this object.
        thisEnemy = gameObject.GetComponent<Enemy>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerDamageableCollider") && Time.time - lastAttackTime >= attackSpeed)
        {
            if (other.gameObject.transform.parent.TryGetComponent<Damageable>(out var enemyDamageable))
            {
                StartCoroutine(thisEnemy.AttackCo());
                var damage = thisEnemy.GetComponent<Damageable>().GetDamage();
                enemyDamageable.TakeDamage(damage);

                // Update the time of the last attack.
                lastAttackTime = Time.time;
            }
        }
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Base") && Time.time - lastAttackTime >= attackSpeed)
        {
            if (other.gameObject.TryGetComponent<Damageable>(out var enemyDamageable))
            {
                StartCoroutine(thisEnemy.AttackCo());
                var damage = thisEnemy.GetComponent<Damageable>().GetDamage();
                enemyDamageable.TakeDamage(damage);

                // Update the time of the last attack.
                lastAttackTime = Time.time;
            }
        }
    }

    public bool GetIsBuffActive()
    {
        return isBuffActive;
    }

    // coroutine to decrease attack damage for 5 seconds
    public IEnumerator DecreaseAttackCo()
    {
        Damageable component = thisEnemy.GetComponent<Damageable>();
        int prevDamageAmount = component.GetDamage();
        component.SetDamage((int)System.Math.Floor(prevDamageAmount * 0.5));
        isBuffActive = true;
        yield return new WaitForSeconds(5.0f);
        isBuffActive = false;
        component.SetDamage(prevDamageAmount);
    }
}
