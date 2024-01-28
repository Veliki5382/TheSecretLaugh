using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lista : MonoBehaviour
{
    public Sprite[] smileSprite;
    public AudioClip[] soundSprite;
    public Vector2 wanted1;
    public Vector2 wanted2;
    public Vector2 wanted3;

    private float startCD;
    private float startCD1;
    bool bioPrvi;

    private void Start()
    {
        startCD = 0.1f;
        wanted2 = new Vector2(-1, -1);
        wanted3 = new Vector2(-1, -1);
    }

    private void FixedUpdate()
    {
        if(!bioPrvi) startCD1 += Time.fixedDeltaTime;
        if (startCD1 >= startCD && !bioPrvi)
        {
            bioPrvi = true;
            wanted1 = NEMOGUVISESVEDATRPAMUENEMYA.FicaFunkcija();
            print (wanted1);
        }

    }
}
