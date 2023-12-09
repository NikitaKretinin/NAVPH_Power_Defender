using System.Collections;
using UnityEngine;

public enum PlayerState
{
    walk,
    attack,
    interact
}

public enum PlayerDirection
{
    up,
    down,
    left,
    right
}

public class PlayerMovement : MonoBehaviour
{
    private bool isBuffActive = false;
    [SerializeField] float speed;
    private Vector3 moveVelocity;
    private Animator anim;
    public PlayerState currentState;
    private Rigidbody2D rb;
    bool isWalking = false;
    [SerializeField] GameObject leftHitbox;
    [SerializeField] GameObject rightHitbox;
    [SerializeField] GameObject upHitbox;
    [SerializeField] GameObject downHitbox;
    PlayerDirection lastDirection = PlayerDirection.down;

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
        switch (GetPlayerDirection())
        {
            case PlayerDirection.up:
                upHitbox.SetActive(true);
                downHitbox.SetActive(false);
                leftHitbox.SetActive(false);
                rightHitbox.SetActive(false);
                break;
            case PlayerDirection.down:
                upHitbox.SetActive(false);
                downHitbox.SetActive(true);
                leftHitbox.SetActive(false);
                rightHitbox.SetActive(false);
                break;
            case PlayerDirection.left:
                upHitbox.SetActive(false);
                downHitbox.SetActive(false);
                leftHitbox.SetActive(true);
                rightHitbox.SetActive(false);
                break;
            case PlayerDirection.right:
                upHitbox.SetActive(false);
                downHitbox.SetActive(false);
                leftHitbox.SetActive(false);
                rightHitbox.SetActive(true);
                break;
        }

        moveVelocity = Vector3.zero;
        moveVelocity.x = Input.GetAxisRaw("Horizontal");
        moveVelocity.y = Input.GetAxisRaw("Vertical");

        bool startAttack = Input.GetButtonDown("attack") && currentState != PlayerState.attack;
        isWalking = currentState == PlayerState.walk;

        if (startAttack)
        {
            StartCoroutine(AttackCo());
        }
    }

    void FixedUpdate()
    {
        if (isWalking)
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
        // transform.position = transform.position + speed * Time.deltaTime * moveVelocity;
        rb.velocity = speed * Time.deltaTime * moveVelocity;
    }

    public bool GetIsBuffActive()
    {
        return isBuffActive;
    }

    // coroutine to increase speed for 5 seconds
    public IEnumerator IncreaseSpeedCo()
    {
        float prevSpeed = speed;
        speed = prevSpeed * 1.3f;
        isBuffActive = true;
        yield return new WaitForSeconds(5.0f);
        isBuffActive = false;
        speed = prevSpeed;
    }

    PlayerDirection GetPlayerDirection()
    {
        if (moveVelocity.x > 0)
        {
            lastDirection = PlayerDirection.right;
        }
        else if (moveVelocity.x < 0)
        {
            lastDirection = PlayerDirection.left;
        }
        else if (moveVelocity.y > 0)
        {
            lastDirection = PlayerDirection.up;
        }
        else if (moveVelocity.y < 0)
        {
            lastDirection = PlayerDirection.down;
        }

        return lastDirection;
    }
}