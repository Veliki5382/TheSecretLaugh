using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    public float jumpingPower = 48f;
    private AudioSource aurdio;
    // Start is called before the first frame update
    void Start()
    {
        aurdio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
            collision.attachedRigidbody.velocity = new Vector2(collision.attachedRigidbody.velocity.x, jumpingPower);
        if (collision.tag == "Player")
        {
            collision.attachedRigidbody.velocity = new Vector2(collision.attachedRigidbody.velocity.x, jumpingPower);
            aurdio.Play();
        }
    }
}
