using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float ms = 8f;
    public float jumpingPower = 16f;

    private float horizontal;
    private float groundedCD;
    private bool canJump;

    void Start()
    {

    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * ms, rb.velocity.y);
        if (!IsGrounded()) groundedCD += Time.fixedDeltaTime;
        else groundedCD = 0;
        if (groundedCD <= 0.001f) canJump = true;
        else canJump = false;   
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.02f, groundLayer);
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if(context.performed && canJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if(context.canceled && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }
}
