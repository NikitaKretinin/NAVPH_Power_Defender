using System;
using System.Collections;
using UnityEngine;

public enum EnemyState
{
    walk,
    attack
}
public class Enemy : MonoBehaviour
{

    [SerializeField] float speed;
    [SerializeField] string enemyName;
    [SerializeField] float chaseRadius;
    [SerializeField] float attackRadius;
    [SerializeField] Transform targetPlayer;
    [SerializeField] Transform targetBase;
    private Animator anim;
    public EnemyState currentState;

    // Start is called before the first frame update
    void Start()
    {
        if (InterScene.gameMode == GameMode.Defense)
        {
            targetBase = GameObject.FindWithTag("Base").transform;
        }
        targetPlayer = GameObject.FindWithTag("Player").transform;
        anim = GetComponent<Animator>();
        currentState = EnemyState.walk;
    }

    // Update is called once per frame
    void Update()
    {
        CheckDistance2();
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

    void CheckDistance2()
    {
        if (currentState == EnemyState.walk)
        {
            // Save current position for comparison
            Vector3 currentPosition = transform.position;
            // If player is in chase radius -> move towards player
            if (Vector3.Distance(targetPlayer.position, transform.position) <= chaseRadius && Vector3.Distance(targetPlayer.position, transform.position) >= attackRadius)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPlayer.position, speed * Time.deltaTime);
            }
            // Otherwise, move towards base (defense mode only)
            else if (InterScene.gameMode == GameMode.Defense)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetBase.position, speed * Time.deltaTime);
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
}
