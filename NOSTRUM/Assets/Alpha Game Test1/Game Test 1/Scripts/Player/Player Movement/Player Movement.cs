using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public PlayerInput inputSys;

    [Header("Attack Settings")]
    private bool attacking = false;
    private float timeToAttack = 0.25f;
    private float timer = 0f;
    


    [Header("Movement Settings")]
    public float horizontal;
    public float vertical;
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public PlayerAnimation playerAnimation;

    private SpriteRenderer spriteRenderer;

    public Collider2D attackCollider;

    private Rigidbody2D rb;
    private bool isGrounded;

    [Header("Coyote & Jump Buffer Settings")]
    private float coyoteTime = 0.15f;
    private float coyoteTimeCounter;
    private float jumpBufferTime = 0.15f;
    private float jumpBufferCounter;

    [Header("Animation Settings")]
    public Animator anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Animator animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Movement(horizontal);
     
        
        if (isGrounded)
        { 
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        if (attacking)
        { 
            timer += Time.deltaTime;
            if (timer >= timeToAttack)
            {
                timer = 0;
                attacking = false;
                attackCollider.enabled = attacking;
                playerAnimation.NotAttacking();
            }

        }

    }

    private void FixedUpdate()
    {

        anim.SetFloat("xVelocity", Mathf.Abs(rb.linearVelocity.x));
        anim.SetFloat("yVelocity", rb.linearVelocity.y);
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (coyoteTimeCounter > 0f && jumpBufferCounter > 0f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            anim.SetBool("IsJumping", true);
            anim.SetFloat("yVelocity", rb.linearVelocity.y);

            jumpBufferCounter = 0f;
        }

        if (context.started)
        {
            jumpBufferCounter = jumpBufferTime;
        }
        else 
        {
            jumpBufferCounter -= Time.deltaTime;
        }
        
        if (context.canceled)
        {
            if (rb.linearVelocity.y > 0)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);

                coyoteTimeCounter = 0f;
            }
        }
        if (isGrounded == false)
        {
            anim.SetBool("IsJumping", true);
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        Attack();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<float>();
        if (horizontal > 0)
        {
            spriteRenderer.flipX = false;
            Vector2 localScale = gameObject.transform.GetChild(0).localScale;
            localScale.x = 0.4396439f;
            gameObject.transform.GetChild(0).localScale = localScale;
        }
        else if (horizontal < 0)
        {
            spriteRenderer.flipX = true;
            Vector2 localScale = gameObject.transform.GetChild(0).localScale;
            localScale.x = -0.4396439f;
            gameObject.transform.GetChild(0).localScale = localScale;

        }
    }

    public void Movement(float value)
    {
        rb.linearVelocity = new Vector2(horizontal * moveSpeed, rb.linearVelocity.y);
        anim.SetFloat("xVelocity", Mathf.Abs(horizontal));
    }

    private void Attack()
    {
        attacking = true;
        attackCollider.enabled = attacking;
        playerAnimation.Attack();
    }

}

