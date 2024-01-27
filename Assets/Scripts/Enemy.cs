using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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
    public SpriteRenderer sr;

    private float horizontal;
    private bool isJumping;
    private float jumpCDmax;
    private float jumpCD;
    private bool isFacingRight; 
    private float flipCD;
    private float flipCDmax;
    private bool nanisanljen = false;

    void Start()
    {
        horizontal = 1f;
        jumpCD= 0f;
        flipCD= 0f;
        jumpCDmax = Random.Range(2,4);
        flipCDmax = Random.Range(2,4);
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * ms * Player.haosLom, rb.velocity.y);
        if (rb.velocity.y > 0) gameObject.layer = 10;
        else gameObject.layer = 8;
        jumpCD += Time.fixedDeltaTime;
        flipCD += Time.fixedDeltaTime;
        if (jumpCD >= jumpCDmax)
        {
            Jump(Random.Range(15,25));
            jumpCD = 0;
            jumpCDmax= Random.Range(2, 4);
        }
        if (flipCD >= flipCDmax)
        {
            horizontal *= -1;
            flipCD = 0;
            flipCDmax = Random.Range(2, 4);
        }
        if (!isFacingRight && horizontal > 0f) Flip();
        else if(isFacingRight && horizontal <0f) Flip();

        if (Mathf.Abs(Nisan.mousePosition.x - transform.position.x) <= 0.5 && Mathf.Abs(Nisan.mousePosition.y - transform.position.y) <= 0.5)
        {
            //zasvetli enemya
            sr.color = Color.magenta;
            if (Input.GetKey(KeyCode.Mouse1) && !nanisanljen)
            {
                nanisanljen = true;
                Nisan.target++;
                print(Nisan.target);
            }
        }
        else
        {
            sr.color= Color.red;
            if (Input.GetKey(KeyCode.Mouse1))
            {
                if (nanisanljen)
                {
                    nanisanljen = false;
                    Nisan.target--;
                }
                print(Nisan.target);
            }
        }
        if (nanisanljen)
        {
            Nisan.nisanPosition = transform.position;
            if (Input.GetKey(KeyCode.Mouse0))
            {
                Groblje.Umri();
                Destroy(gameObject);
                Nisan.target--;
                Player.haosLom = Player.haosMax;
                print(Nisan.target);
            }
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

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale= transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Enemy")
        {
            horizontal *= -1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Pero")
        {
            //smej se
        }
    }
}
