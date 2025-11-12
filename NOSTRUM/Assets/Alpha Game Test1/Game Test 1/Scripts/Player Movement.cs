using System;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    
    private SpriteRenderer spriteRenderer;
    
    private Rigidbody2D rb;
    private bool isGrounded;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    private void FixedUpdate()
    {
        
        if (Input.GetAxisRaw("Horizontal") > 0)
            spriteRenderer.flipX = false;
        else if (Input.GetAxisRaw("Horizontal") < 0)
            spriteRenderer.flipX = true;
        
        isGrounded =  Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }
}

