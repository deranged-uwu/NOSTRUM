using System;
using UnityEngine;
 using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    public InputSystem_Actions actions; 
    
    public float speed = 5f;
    public float jumpForce = 10f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public SpriteRenderer spriteRenderer;
    
    
    float move;
    
    Rigidbody2D rb;
    private bool isGrounded;
    void Awake()
    {
        actions = new InputSystem_Actions();
    }

    void OnEnable()
    {
        actions.Player.Enable();
        actions.Player.Move.performed += Movement;
        actions.Player.Jump.performed += Jumping;
        
        actions.Player.Move.canceled += Movement;
        actions.Player.Jump.canceled += Jumping;
    }

    void OnDisable()
    {
        actions.Player.Disable();
        actions.Player.Move.performed -= Movement;
        actions.Player.Jump.performed -= Jumping;
    }

    void Movement(InputAction.CallbackContext ctx)
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector3(moveInput * speed, rb.linearVelocity.y);
    }

    void Jumping(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            if  (isGrounded)
            {
                 rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce);
            }
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        
        
    }
    
}
