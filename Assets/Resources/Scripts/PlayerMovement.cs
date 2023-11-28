using System.Collections;
using UnityEngine;

public enum PlayerState
{
    walk,
    attack,
    interact
}

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] float speed = 10.0f;
    private Vector3 moveVelocity;
    private Animator anim;
    public PlayerState currentState;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        currentState = PlayerState.walk;
    }

    // Update is called once per frame
    void Update()
    {
        moveVelocity = Vector3.zero;
        moveVelocity.x = Input.GetAxisRaw("Horizontal");
        moveVelocity.y = Input.GetAxisRaw("Vertical");
        if (Input.GetButtonDown("attack") && currentState != PlayerState.attack)
        {
            StartCoroutine(AttackCo());
        }
        else if (currentState == PlayerState.walk)
        {
            UpdateAnimationAndMove();
        }
    }

    private IEnumerator AttackCo()
    {
        anim.SetBool("attacking", true);
        currentState = PlayerState.attack;
        yield return null;
        anim.SetBool("attacking", false);
        yield return new WaitForSeconds(.3f);
        currentState = PlayerState.walk;
    }

    void UpdateAnimationAndMove()
    {
        if (moveVelocity != Vector3.zero)
        {
            MoveCharacter();
            anim.SetFloat("moveX", moveVelocity.x);
            anim.SetFloat("moveY", moveVelocity.y);
            anim.SetBool("walking", true);
        }
        else
        {
            anim.SetBool("walking", false);
        }
    }

    void MoveCharacter()
    {
        moveVelocity.Normalize();
        //rb.MovePosition(transform.position + speed * Time.deltaTime * moveVelocity);
        transform.position = transform.position + speed * Time.deltaTime * moveVelocity;
    }
}
