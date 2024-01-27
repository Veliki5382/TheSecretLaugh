using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Groblje : MonoBehaviour
{
    private static AudioSource aurdio;
    public static AudioClip killSfx;
    // Start is called before the first frame update
    void Start()
    {
        aurdio = GetComponent<AudioSource>();
    }

    public static void Umri()
    {
        aurdio.Play();
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
