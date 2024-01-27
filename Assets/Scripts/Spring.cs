using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    public Rigidbody2D rbPlayer;
    public Rigidbody2D rbEnemy;
    public float jumpingPower = 48f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.attachedRigidbody == rbEnemy)
            rbEnemy.velocity = new Vector2(rbEnemy.velocity.x, jumpingPower);
        else
            rbPlayer.velocity = new Vector2(rbPlayer.velocity.x, jumpingPower);
    }
}
