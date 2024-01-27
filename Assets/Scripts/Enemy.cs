using System.Collections;
using System.Collections.Generic;
using System.Threading;
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
    public GameObject smile;
	public GameObject eye;
	public GameObject hat;
	//public GameObject smile1;
	public Sprite[] smileSprite;
	public Sprite[] eyeSprite;
	public Sprite[] hatSprite;
    public Vector3 smileOffset;
    public Vector3 eyeOffset;
    public Vector3 hatOffset;

	[SerializeField] private int n;
    private int smileNumber;
	private int colorNumber;
	private int eyeNumber;
	private int hatNumber;
    private Color enemyColor;
	private float horizontal;
    public AudioClip laughSfx;

    private AudioSource aurdio;
    private bool isJumping;
    private float jumpCDmax;
    private float jumpCD;
    private bool isFacingRight;
    private float flipCD;
    private float flipCDmax;
    private bool nanisanljen = false;

    static bool[] enemyCombination;

    void Start()
    {
        aurdio = GetComponent<AudioSource>();
        horizontal = 1f;
        jumpCD= 0f;
        flipCD= 0f;
        jumpCDmax = Random.Range(2,4);
        flipCDmax = Random.Range(2,4);

        smile = Instantiate(smile, transform.position, Quaternion.identity);
        smile.transform.position = transform.position + smileOffset;
        eye = Instantiate(eye, transform.position, Quaternion.identity);
        eye.transform.position = transform.position + eyeOffset;
        hat = Instantiate(hat, transform.position, Quaternion.identity);
        hat.transform.position = transform.position + hatOffset;

		n = 10;
		RandomCombination();

    }

void RandomCombination()
	{
		smileNumber = Random.Range(1, n);
		colorNumber = Random.Range(1, n);
		eyeNumber = Random.Range(1, n);
		hatNumber = Random.Range(1, n);
        enemyColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        GetComponent<SpriteRenderer>().material.color = enemyColor;

        enemyCombination = new bool[n * n * n * n + 2];

        if (enemyCombination[smileNumber * n * n * n + colorNumber * n * n + eyeNumber * n + hatNumber] == true)
		{
			RandomCombination();
			return;
		}
		else
		{
			enemyCombination[smileNumber * n * n * n + colorNumber * n * n + eyeNumber * n + hatNumber] = true;

            smile.GetComponent<SpriteRenderer>().sprite = smileSprite[smileNumber - 1];
			eye.GetComponent<SpriteRenderer>().sprite = eyeSprite[eyeNumber - 1];
            hat.GetComponent<SpriteRenderer>().sprite = hatSprite[hatNumber - 1];
		}
	}

    float timer = 2;

	void Update()
	{
		smile.transform.position = transform.position + smileOffset;
        eye.transform.position = transform.position + eyeOffset;
        hat.transform.position = transform.position + hatOffset;

		if (Time.time > timer) { smile.GetComponent<SpriteRenderer>().enabled ^= true; timer += 2; }
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

        if (Mathf.Abs(Nisan.mousePosition.x - transform.position.x) <= 1 && Mathf.Abs(Nisan.mousePosition.y - transform.position.y) <= 1)
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
            sr.color = enemyColor;
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
                Splat.Kill(transform);
                Groblje.Umri();
				enemyCombination[smileNumber * n * n * n + colorNumber * n * n + eyeNumber * n + hatNumber] = false;
				Destroy(gameObject);
                Nisan.target--;
                Player.haosLom = Player.haosMax;
                print(Nisan.target);
                Player.time += 15;
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
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Enemy"))
        {
            horizontal *= -1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pero"))
        {
            //smej se
            aurdio.PlayOneShot(laughSfx);
        }
    }
}
