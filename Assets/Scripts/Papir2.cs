using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Papir2 : MonoBehaviour
{
    public Sprite[] smileSprite;
    public AudioClip[] soundSprite;
    public Vector2 wanted;
    public Image osmeh;
    public AudioSource aurdio;
    public RectTransform rt;
    public float ms;
    public RectTransform score;

    private bool bioPrvi;
    private bool pomeranjeLevo;
    private bool pomeranjeDesno;
    private float pocPozX;
    private bool moze;
    private bool moze1;

    private void Start()
    {
        pocPozX = score.transform.position.x-150;
        transform.position = new Vector2(-400,transform.position.y);
        moze = false;
        moze1 = true;
        wanted = new Vector2(-1, -1);
    }

    private void FixedUpdate()
    {
        //print(rt.transform.position);
        //print(pomeranjeLevo);
        if (Player.score >= 1) moze = true;
        if (pomeranjeLevo && rt.transform.position.x >= -120)
        {
            rt.transform.position = rt.transform.position - new Vector3(Time.fixedDeltaTime * ms, 0, 0);
        }
        if (rt.transform.position.x <= -120 && moze && moze1)
        {
            pomeranjeLevo = false;
            wanted = NEMOGUVISESVEDATRPAMUENEMYA.FicaFunkcija();
            print(wanted);
            osmeh.sprite = smileSprite[(int)wanted.x];
            pomeranjeDesno = true;
            moze1 = false;
        }
        if (rt.transform.position.x <= pocPozX && pomeranjeDesno)
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
        if (!Input.GetKey(KeyCode.Space) && wanted.y>=0) aurdio.PlayOneShot(soundSprite[(int)wanted.y], 0.2f);
    }

    public void PomeriPaVrati()
    {
        pomeranjeLevo = true;
        moze1 = true;
    }
}
