using System.Collections;
using System.Collections.Generic;
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
        targetBase = GameObject.FindWithTag("Base").transform;
        targetPlayer = GameObject.FindWithTag("Player").transform;
        anim = GetComponent<Animator>();
        currentState = EnemyState.walk;
    }

    // Update is called once per frame
    void Update()
    {
        
        CheckDistance();
    }

    private IEnumerator AttackCo()
    {
        Debug.Log("Attack");
        anim.SetBool("attacking", true);
        currentState = EnemyState.attack;
        yield return null;
        anim.SetBool("attacking", false);
        yield return new WaitForSeconds(1.0f);
        currentState = EnemyState.walk;
    }

    void CheckDistance()
    {
        // Save current position for comparison
        Vector3 currentPosition = transform.position;      
        if (Vector3.Distance(targetPlayer.position, transform.position) <= chaseRadius)
        {
            // -0.5 is a correction for animation to start, but not interrupt box colliders collision
            if (Vector3.Distance(targetPlayer.position, transform.position) <= attackRadius && currentState != EnemyState.attack) 
            {
                StartCoroutine(AttackCo());
            }
            else 
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPlayer.position, speed * Time.deltaTime);
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, targetBase.position, speed * Time.deltaTime);
        }
        anim.SetFloat("moveX", transform.position.x - currentPosition.x);
    }
}
