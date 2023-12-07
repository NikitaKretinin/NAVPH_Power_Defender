using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    private bool isBuffActive = false;
    public int damageAmount = 10; // Adjust the damage amount as needed.
    [SerializeField] float attackSpeed = 1.0f; // The time between consecutive attacks in seconds.
    [SerializeField] Enemy thisEnemy; // Reference to the Enemy script component on this object.
    private float lastAttackTime = 0.0f; // The time of the last attack.

    // Start is called before the first frame update
    void Start()
    {   
        // Get the Enemy script component from this object.
        thisEnemy = gameObject.GetComponent<Enemy>();
        damageAmount = thisEnemy.GetComponent<Damageable>().getDamage();
    }
    
    void Update()
    {
        damageAmount = thisEnemy.GetComponent<Damageable>().getDamage();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if ((collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Base")) && Time.time - lastAttackTime >= attackSpeed)
        {
            Debug.Log("Enemy attacking");
            if (collision.gameObject.TryGetComponent<Damageable>(out var enemyDamageable))
            {
                Debug.Log("Enemy attacking2");
                StartCoroutine(thisEnemy.AttackCo());
                enemyDamageable.TakeDamage(damageAmount);

                // Update the time of the last attack.
                lastAttackTime = Time.time;
            }
        }
    }
    
    public bool getIsBuffActive()
    {
        return isBuffActive;
    }
    
    public IEnumerator DecreaseAttackCo()
    {
        Damageable component = thisEnemy.GetComponent<Damageable>();
        int prevDamageAmount = component.getDamage();
        component.setDamage((int)System.Math.Floor(prevDamageAmount * 0.5));
        isBuffActive = true;
        yield return new WaitForSeconds(5.0f);
        isBuffActive = false;
        component.setDamage(prevDamageAmount);
    }
}
