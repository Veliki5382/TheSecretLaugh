using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform groundCheckLeft;
    public Transform groundCheckRight;
    public LayerMask groundLayer;
    public float ms = 8f;
    public Collider2D colider;
    public float CD = 0f;

    private float horizontal;
    private bool isJumping;
    private float jumpCDmax;
    private float jumpCD;

    void Start()
    {
        horizontal = 1f;
        jumpCD= 0f;
        jumpCDmax = Random.Range(2,6);
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * ms, rb.velocity.y);
        if (rb.velocity.y > 0) colider.isTrigger = true;
        else colider.isTrigger = false;
        jumpCD += Time.fixedDeltaTime;
        if (jumpCD >= jumpCDmax)
        {
            Jump(Random.Range(15,25));
            jumpCD = 0;
            jumpCDmax= Random.Range(2, 6);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheckLeft.position, 0.02f, groundLayer) || Physics2D.OverlapCircle(groundCheckRight.position, 0.02f, groundLayer);
    }

    public void Jump(float jumpingPower)
    {
        if (IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }
    }
}
