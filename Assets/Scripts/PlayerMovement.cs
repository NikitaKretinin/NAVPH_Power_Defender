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
    private bool isBuffActive = false;
    [SerializeField] float speed;
    private Vector3 moveVelocity;
    private Animator anim;
    public PlayerState currentState;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
            rb.velocity = Vector3.zero;
            anim.SetBool("walking", false);
        }
    }

    void MoveCharacter()
    {
        moveVelocity.Normalize();
        //rb.MovePosition(transform.position + speed * Time.deltaTime * moveVelocity);
        transform.position = transform.position + speed * Time.deltaTime * moveVelocity;
        // rb.velocity = speed * Time.deltaTime * moveVelocity;
    }

    public bool getIsBuffActive()
    {
        return isBuffActive;
    }
    
    public IEnumerator IncreaseSpeedCo()
    {
        float prevSpeed = speed;
        speed = prevSpeed * 1.1f;
        isBuffActive = true;
        yield return new WaitForSeconds(5.0f);
        isBuffActive = false;
        speed = prevSpeed;
    }
}