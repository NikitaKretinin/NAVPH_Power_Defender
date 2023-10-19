using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed;
    public int health;
    public int damage;
    public string enemyName;
    public float chaseRadius;
    public float attackRadius;
    public Transform targetPlayer;
    public Transform targetBase;


    // Start is called before the first frame update
    void Start()
    {
        targetBase = GameObject.FindWithTag("Base").transform;
        targetPlayer = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        CheckDistance();
    }

    void CheckDistance()
    {
        if (Vector3.Distance(targetPlayer.position, transform.position) <= chaseRadius && Vector3.Distance(targetPlayer.position, transform.position) > attackRadius)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPlayer.position, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, targetBase.position, speed * Time.deltaTime);
        }
    }
}
