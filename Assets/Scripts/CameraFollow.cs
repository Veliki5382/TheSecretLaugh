using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 offset = new Vector3(0, 0, -10);
    private float smoothTime = 0.3f;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] private Transform target;
    [SerializeField] private float yOffset = 0.8f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    Vector3 packY(Vector3 v, float coff)
    {
        return new Vector3(v.x, v.y * coff, v.z);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(packY(transform.position, yOffset),
            packY(targetPosition, yOffset), ref velocity, smoothTime);
    }
}
