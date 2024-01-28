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
    public RectTransform score;

    private float startCD;
    private float startCD1;
    private bool bioPrvi;
    private bool pomeranjeLevo;
    private bool pomeranjeDesno;
    private float pocPozX;
    private float pocPozY;


    private void Start()
    {
        startCD = 0.1f;
        pocPozX=score.transform.position.x- 150 / 1115 * Screen.width;
    }

    private void FixedUpdate()
    {
        if (!bioPrvi) startCD1 += Time.fixedDeltaTime;
        if (startCD1 >= startCD && !bioPrvi)
        {
            bioPrvi = true;
            wanted = NEMOGUVISESVEDATRPAMUENEMYA.FicaFunkcija();
            osmeh.sprite = smileSprite[(int)wanted.x];
        }
        //print(rt.transform.position);
        //print(pomeranjeLevo);
        if(pomeranjeLevo && rt.transform.position.x >= -120)
        {
            rt.transform.position=rt.transform.position-new Vector3(Time.fixedDeltaTime*ms,0,0);
        }
        if (rt.transform.position.x <= -120)
        {
            pomeranjeLevo = false;
            wanted = NEMOGUVISESVEDATRPAMUENEMYA.FicaFunkcija();
            print(wanted);
            osmeh.sprite = smileSprite[(int)wanted.x];
            pomeranjeDesno = true;
        }
        if(rt.transform.position.x<=pocPozX && pomeranjeDesno)
        {
            rt.transform.position = rt.transform.position + new Vector3(Time.fixedDeltaTime * ms, 0, 0);
        }
        if (rt.transform.position.x >= pocPozX)
        {
            pomeranjeDesno = false;
        }
        //print(rt.transform.position.x);
    }

    public void PlaySound()
    {
        if (!Input.GetKey(KeyCode.Space) && wanted.y >= 0) aurdio.PlayOneShot(soundSprite[(int)wanted.y],0.07f);
    }

    public void PomeriPaVrati()
    {
        pomeranjeLevo = true;
    }
}
