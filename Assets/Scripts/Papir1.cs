using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Papir1 : MonoBehaviour
{
    public Sprite[] smileSprite;
    public AudioClip[] soundSprite;
    public Vector2 wanted;
    public Image osmeh;
    public AudioSource aurdio;
    public RectTransform rt;
    public float ms;

    private float startCD;
    private float startCD1;
    private bool bioPrvi;
    private bool pomeranjeLevo;

    private void Start()
    {
        startCD = 0.1f;
    }

    private void FixedUpdate()
    {
        if (!bioPrvi) startCD1 += Time.fixedDeltaTime;
        if (startCD1 >= startCD && !bioPrvi)
        {
            bioPrvi = true;
            wanted = Enemy.FicaFunkcija();
            osmeh.sprite = smileSprite[(int)wanted.x];
        }
        print(rt.transform.position);
        print(pomeranjeLevo);
        if(pomeranjeLevo && rt.transform.position.x >= 0)
        {
            rt.transform.position=rt.transform.position-new Vector3(Time.fixedDeltaTime*ms,0,0);
        }
        if(transform.position.x ==0) pomeranjeLevo = false;
    }

    public void PlaySound()
    {
        if (!Input.GetKey(KeyCode.Space)) aurdio.PlayOneShot(soundSprite[(int)wanted.y],0.2f);
    }

    public void PomeriPaVrati()
    {
        pomeranjeLevo = true;
    }
}
