using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public static float haosLom;
    public static float haosMax;
    public static float time;
    public static float score;
    public static bool umro;

    public Rigidbody2D rb;
    public Transform groundCheckLeft;
    public Transform groundCheckRight;
    public LayerMask groundLayer;
    public float ms = 8f;
    public float jumpingPower = 16f;
    public Collider2D colider;
    public GameObject pero;
    public AudioClip jumpSfx;
    public GameObject pistolj;
    public Animator animator;
    public Papir1 papir1;
    public Papir2 papir2;
    public Papir3 papir3;
    public GameObject game;
    public GameObject ostalo;
    public GameObject deathscreen;

    private float horizontal;
    private float groundedCD;
    private bool canJump;
    private bool isFacingRight;
    private AudioSource aurdio;

    void Start()
    {
        aurdio = GetComponent<AudioSource>();
        haosLom = 1;
        haosMax = 2;
        time = 30;
        umro = false;
    }

    void FixedUpdate()
    {
        
        //print(score);
        time -= Time.fixedDeltaTime;
        if (time < 0) umro = true;
        
        rb.velocity = new Vector2(horizontal * ms, rb.velocity.y);
        if (!IsGrounded()) groundedCD += Time.fixedDeltaTime;
        else groundedCD = 0;
        
        if (groundedCD <= 0.1f) canJump = true;
        else canJump = false;
        
        if (rb.velocity.y > 0) Physics2D.IgnoreLayerCollision(6,7, true);
        else Physics2D.IgnoreLayerCollision(6, 7, false);
        
        if (!isFacingRight && horizontal > 0f) Flip();
        else if (isFacingRight && horizontal < 0f) Flip();
        
        if (horizontal == 0) animator.Play("PLayerIdleStv");
        else animator.Play("PlayerIdle");
        if (pero.gameObject.activeSelf)
        {
            haosLom += Time.fixedDeltaTime;
            haosLom = Mathf.Min(haosLom, haosMax);
        }
        else
        {
            haosLom -= Time.fixedDeltaTime/2;
            haosLom= Mathf.Max(haosLom, 1);
        }
        if (Nisan.target == 1) pistolj.gameObject.SetActive(true);
        else pistolj.gameObject.SetActive(false);
        if (umro) Umri();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) papir1.PlaySound();
        if (Input.GetKeyDown(KeyCode.Alpha2)) papir2.PlaySound();
        if (Input.GetKeyDown(KeyCode.Alpha3)) papir3.PlaySound();
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
            aurdio.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if(context.canceled && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }

    public void VadiPero(InputAction.CallbackContext context)
    {
        print("asfddfas");
        if (context.performed && Input.GetKey(KeyCode.Mouse1)==false)
        {
            pero.gameObject.SetActive(true);
        }
        else
        {
            pero.gameObject.SetActive(false);
        }
    }
    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    public void Click1(InputAction.CallbackContext context)
    {
        print("sdfhijofgsdhj");
    }

    public void Click2(InputAction.CallbackContext context) 
    {
        papir2.PlaySound();
    }

    public void Click3(InputAction.CallbackContext context)
    {
        papir3.PlaySound();
    }
    
    public void Umri()
    {
        game.SetActive(false);
        ostalo.SetActive(false);
        deathscreen.SetActive(true);
    }
}
