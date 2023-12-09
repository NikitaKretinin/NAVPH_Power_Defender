using System.Collections;
using UnityEngine;

public enum EnemyState
{
    walk,
    attack
}
public class Enemy : MonoBehaviour
{
    private bool isBuffActive = false;
    [SerializeField] float speed;
    [SerializeField] string enemyName;
    [SerializeField] float chaseRadius;
    [SerializeField] float attackRadius;
    [SerializeField] Transform targetPlayer;
    [SerializeField] Transform targetBase;
    [SerializeField] GameObject globalInventoryObject = null;
    private Animator anim;
    public EnemyState currentState;
    private Rigidbody2D rb;
    private GlobalInventoryBehaviour globalInventory = null;

    // Start is called before the first frame update
    void Start()
    {
        if (InterScene.gameMode == GameMode.Defense)
        {
            targetBase = GameObject.FindWithTag("Base").transform;
        }
        rb = GetComponent<Rigidbody2D>();
        targetPlayer = GameObject.FindWithTag("Player").transform;
        anim = GetComponent<Animator>();
        currentState = EnemyState.walk;
        // Adjust the stats using coefficient for enemies.
        if (GetComponent<Damageable>() != null && globalInventoryObject != null)
        {
            globalInventory = globalInventoryObject.GetComponent<GlobalInventoryBehaviour>();
            float coef = 1.0f;
            if (InterScene.gameMode == GameMode.Defense)
            {
                coef += 0.2f * globalInventory.GetCurrentDefenseLevel();
            } 
            else
            {
                coef += 0.2f * globalInventory.GetCurrentAttackLevel();
            }
            GetComponent<Damageable>().setCoefficient(coef);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckDistance();
    }

    // Will be called from the attack script
    public IEnumerator AttackCo()
    {
        anim.SetBool("walking", false);
        anim.SetBool("attacking", true);
        currentState = EnemyState.attack;
        yield return null;
        anim.SetBool("attacking", false);
        yield return new WaitForSeconds(2f);
        currentState = EnemyState.walk;
    }

    // function manages enemy movement
    void CheckDistance()
    {
        if (currentState == EnemyState.walk)
        {
            // Save current position for comparison
            Vector3 currentPosition = transform.position;
            // If player is in chase radius -> move towards player
            if (Vector3.Distance(targetPlayer.position, transform.position) <= chaseRadius && Vector3.Distance(targetPlayer.position, transform.position) >= attackRadius)
            {
                var moveVector = Vector2.MoveTowards(transform.position, targetPlayer.position, speed * Time.fixedDeltaTime);
                rb.MovePosition(moveVector);
            }
            // Otherwise, move towards base (defense mode only)
            else if (InterScene.gameMode == GameMode.Defense)
            {
                var moveVector = Vector2.MoveTowards(transform.position, targetBase.position, speed * Time.fixedDeltaTime);
                rb.MovePosition(moveVector);
            }
            // If enemy is not attacking -> set walking animation state
            anim.SetBool("walking", true);
            // If enemy hasn't moved, do not reset moveX value to 0, to prevent animation from resetting
            if ((transform.position.x - currentPosition.x) != 0)
            {
                anim.SetFloat("moveX", transform.position.x - currentPosition.x);
            }
        }
    }
    public bool getIsBuffActive()
    {
        return isBuffActive;
    }

    // Coroutine to decrease speed for 5 seconds
    public IEnumerator DecreaseSpeedCo()
    {
        float prevSpeed = speed;
        speed = prevSpeed * 0.5f;
        isBuffActive = true;
        yield return new WaitForSeconds(5.0f);
        isBuffActive = false;
        speed = prevSpeed;
    }
}
