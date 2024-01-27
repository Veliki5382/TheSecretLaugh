using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform RightEdge;
    public Transform LeftEdge;
    public float ms = 0.4f;
    public float smoothTime = 0.3f;
    private Vector3 velocity = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position, transform.position + new Vector3(ms, 0, 0), ref velocity, smoothTime);
    }
}
