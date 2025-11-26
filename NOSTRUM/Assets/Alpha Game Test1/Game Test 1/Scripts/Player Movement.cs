using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [Header("Attack Settings")]
    private GameObject attackArea = default;
    private bool attacking = false;
    private float timeToAttack = 0.25f;
    private float timer = 0f;



    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    private SpriteRenderer spriteRenderer;


    private Rigidbody2D rb;
    private bool isGrounded;

    [Header("Coyote & Jump Buffer Settings")]
    private float coyoteTime = 0.15f;
    private float coyoteTimeCounter;
    private float jumpBufferTime = 0.15f;
    private float jumpBufferCounter;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        attackArea = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        if (coyoteTimeCounter > 0f && jumpBufferCounter > 0f)

        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);

            jumpBufferCounter = 0f;
        }
     
        
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (rb.linearVelocity.y > 0)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);

                coyoteTimeCounter = 0f;
            }
        }

        if (Input.GetKeyUp(KeyCode.Joystick1Button1) || Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            if (rb.linearVelocity.y > 0)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);

                coyoteTimeCounter = 0f;
            }

        }
        if (isGrounded)
        { 
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpBufferCounter = jumpBufferTime;
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }

        if(Input.GetKeyDown(KeyCode.Joystick1Button1) || Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            jumpBufferCounter = jumpBufferTime;
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.Joystick1Button2))
        {
            Attack();
        }

        if (attacking)
        { 
            timer += Time.deltaTime;
            if (timer >= timeToAttack)
            {
                timer = 0;
                attacking = false;
                attackArea.SetActive(attacking);
            }
        }

    }

    private void FixedUpdate()
    {

        if (Input.GetAxisRaw("Horizontal") > 0)
            spriteRenderer.flipX = false;
        else if (Input.GetAxisRaw("Horizontal") < 0)
            spriteRenderer.flipX = true;

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    private void Attack()
    {
        attacking = true;
        attackArea.SetActive(attacking);
    }

}

