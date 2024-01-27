using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nisan : MonoBehaviour
{
    public static Vector2 mousePosition;
    public static Vector2 nisanPosition;
    public static int target;

    public SpriteRenderer sr;

    private void Start()
    {
        target = 0;
    }

    void FixedUpdate()
    {
        if(target==1) sr.enabled = true;
        if(target==0) sr.enabled = false;
        Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        mousePosition = Camera.main.ScreenToWorldPoint(screenPosition);
        transform.position = nisanPosition;
    }
}
