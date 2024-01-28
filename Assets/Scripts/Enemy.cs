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
    public SpriteRenderer sr;
    public GameObject smile;
	public GameObject eye;
	public GameObject hat;
	//public GameObject smile1;
	public Sprite[] smileSprite;
	public Sprite[] eyeSprite;
	public Sprite[] hatSprite;
    public AudioClip[] soundSprite;
    public Vector3 smileOffset;
    public Vector3 eyeOffset;
    public Vector3 hatOffset;
    public GameObject LeftLeg;
    public GameObject RightLeg;
    public GameObject controller;
    public float smileTimer = 100;
    public float smileTime = 0;

    private int smileNumber;
	private int eyeNumber;
	private int hatNumber;
    private int soundNumber;
    private Color enemyColor;
	private float horizontal;
    public AudioClip laughSfx;
    public Papir1 papir1;
    public Papir2 papir2;
    public Papir3 papir3;

    private AudioSource aurdio;
    private bool isJumping;
    private float jumpCDmax;
    private float jumpCD;
    private bool isFacingRight;
    private float flipCD;
    private float flipCDmax;
    private bool nanisanljen = false;

	[SerializeField] static private int n;
	[SerializeField] static private int m;
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
        m = 13;
		RandomCombination();
        LeftLeg.GetComponent<SpriteRenderer>().color = enemyColor;
        RightLeg.GetComponent<SpriteRenderer>().color = enemyColor;
        papir1 = GameObject.FindWithTag("Papir1").GetComponent<Papir1>();
        papir2 = GameObject.FindWithTag("Papir2").GetComponent<Papir2>();
        papir3 = GameObject.FindWithTag("Papir3").GetComponent<Papir3>();
    }

    void RandomCombination()
	{
		smileNumber = Random.Range(0, n-1);
		eyeNumber = Random.Range(0, n-1);
		hatNumber = Random.Range(0, n-1);
        soundNumber = Random.Range(0, m-1);

        enemyColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        GetComponent<SpriteRenderer>().material.color = enemyColor;

        enemyCombination = new bool[(n+1)*(n+1)*(n+1)];

        if (enemyCombination[smileNumber * n * n + eyeNumber * n + hatNumber] == true ||
            NEMOGUVISESVEDATRPAMUENEMYA.killCombination[smileNumber, soundNumber] == true)
		{
			RandomCombination();
			return;
		}
		else
		{
			enemyCombination[smileNumber * n * n + eyeNumber * n + hatNumber] = true;
            NEMOGUVISESVEDATRPAMUENEMYA.killCombination[smileNumber, soundNumber] = true;

            smile.GetComponent<SpriteRenderer>().sprite = smileSprite[smileNumber];
            smile.GetComponent<SpriteRenderer>().enabled = false;
            eye.GetComponent<SpriteRenderer>().sprite = eyeSprite[eyeNumber];
            hat.GetComponent<SpriteRenderer>().sprite = hatSprite[hatNumber];
            laughSfx = soundSprite[soundNumber];
		}
	}



	void Update()
    {
        smile.transform.position = transform.position + smileOffset;
        eye.transform.position = transform.position + eyeOffset;
        hat.transform.position = transform.position + hatOffset;

        if (Input.GetKey(KeyCode.Mouse1) && !nanisanljen &&
            Mathf.Abs(Nisan.mousePosition.x - transform.position.x) <= 1 && Mathf.Abs(Nisan.mousePosition.y - transform.position.y) <= 1)
        {
            nanisanljen = true;
            Nisan.target++;
            print(Nisan.target);
        }

        ///


        if (smileTime < smileTimer)
        {
            smileTime++;
        }
        else if(smileTime>=smileTimer)
        {
            smile.GetComponent<SpriteRenderer>().enabled = false;
        }

		rb.velocity = new Vector2(horizontal * ms * Player.haosLom, rb.velocity.y);
        if (rb.velocity.y > 0) gameObject.layer = 10;
        else gameObject.layer = 8;
        jumpCD += Time.deltaTime;
        flipCD += Time.deltaTime;
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
            
        }
        else
        {
            sr.color = enemyColor;
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                if (nanisanljen)
                {
                    nanisanljen = false;
                    Nisan.target--;
                }
                //print(Nisan.target);
            }
        }
        if (nanisanljen)
        {
            Nisan.nisanPosition = transform.position;
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                //GetComponent<EnemySpawner>().Spawn();
                Splat.Kill(transform);
                Groblje.Umri();
				enemyCombination[smileNumber * n * n + eyeNumber * n + hatNumber] = false;
                NEMOGUVISESVEDATRPAMUENEMYA.killCombination[smileNumber, soundNumber] = false;
                NEMOGUVISESVEDATRPAMUENEMYA.expectedEnemies += 2;
                Nisan.target--;
                Player.haosLom = Player.haosMax;
                print(Nisan.target);
                Player.time += 15;
                if (smileNumber == (int)papir1.wanted.x && soundNumber == (int)papir1.wanted.y)
                {
                    papir1.PomeriPaVrati();
                    Player.score++;
                    print("naso");
                }
                else if(smileNumber == (int)papir2.wanted.x && soundNumber == (int)papir2.wanted.y)
                {
                    papir2.PomeriPaVrati();
                    Player.score++;
                }
                else if (smileNumber == (int)papir3.wanted.x && soundNumber == (int)papir3.wanted.y)
                {
                    papir3.PomeriPaVrati();
                    Player.score++;
                }
                else
                {
                    Player.umro = true;
                    papir1.PomeriPaVrati();
                    Player.score++;
                }
                Destroy(smile);
                Destroy(eye);
                Destroy(hat);
                Destroy(gameObject);
            }
        }



    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheckLeft.position, 0.1f, groundLayer) || Physics2D.OverlapCircle(groundCheckRight.position, 0.1f, groundLayer);
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
            aurdio.PlayOneShot(laughSfx, 0.2f);
            smile.GetComponent<SpriteRenderer>().enabled = true;
            smileTime = 0;
        }
    }
}
