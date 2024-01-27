using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Splat : MonoBehaviour
{
    public static Vector3 porsition = new Vector3(0, -20, 0);
    private static int timer=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public static void Kill(Transform location)
    {
        porsition = location.position;
        timer = 100;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = porsition;
        if(timer > 0)
        {
            timer--;
        }
        else if (timer <= 0)
        {
            porsition.Set(0, -20, 0);
        }
    }
}
