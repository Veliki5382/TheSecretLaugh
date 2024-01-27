using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float range = 5;
    private float yStart;
    public float direction = 1;
    public float ms = 0.6f;
    public float smoothTime = 0.3f;
    private Vector3 velocity = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        yStart = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position, transform.position + new Vector3(0, direction * ms, 0), ref velocity, smoothTime);
        if (yStart - transform.position.y < -range && direction == 1)
            direction = -1;
        else if (yStart - transform.position.y > range && direction == -1)
            direction = 1;
    }
}
