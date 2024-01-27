using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nisan : MonoBehaviour
{
    public static Vector2 mousePosition;
    public static Vector2 nisanPosition;
    public static int target;
    private AudioSource aurdio;
    public AudioClip cockSfx;
    public AudioClip holsterSfx;

    public SpriteRenderer sr;

    private bool canCock = true;
    private bool canHolster = false;

    private void Start()
    {
        target = 0;
        aurdio = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        if (target == 1)
        { 
            sr.enabled = true;
            canHolster = true;
            if(canCock)
            {
                aurdio.PlayOneShot(cockSfx);
                canCock = false;
            }
        }
        if (target == 0)
        {
            sr.enabled = false;
            canCock = true;
            if(canHolster)
            {
                aurdio.PlayOneShot(holsterSfx);
                canHolster = false;
            }
        }
        Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        mousePosition = Camera.main.ScreenToWorldPoint(screenPosition);
        transform.position = nisanPosition;
    }
}
