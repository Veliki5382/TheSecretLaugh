using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform groundCheckLeft;
    public Transform groundCheckRight;
    public LayerMask groundLayer;
    public float ms = 8f;
    public float jumpingPower = 16f;
    public Collider2D colider;

    private float horizontal;
    private float groundedCD;
    private bool canJump;
    private bool isFacingRight;

    void Start()
    {

    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * ms, rb.velocity.y);
        if (!IsGrounded()) groundedCD += Time.fixedDeltaTime;
        else groundedCD = 0;
        if (groundedCD <= 0.1f) canJump = true;
        else canJump = false;
        if (rb.velocity.y > 0) Physics2D.IgnoreLayerCollision(6,7, true);
        else Physics2D.IgnoreLayerCollision(6, 7, false);
        if (!isFacingRight && horizontal > 0f) Flip();
        else if (isFacingRight && horizontal < 0f) Flip();
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheckLeft.position, 0.02f, groundLayer) || Physics2D.OverlapCircle(groundCheckRight.position, 0.02f, groundLayer);
    }

    public void Move(InputAction.CallbackContext context)
    {
        if (context.ReadValue<Vector2>().x > 0) horizontal = 1;
        else if(context.ReadValue<Vector2>().x < 0) horizontal = -1;
        else horizontal = 0;
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
    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

}
