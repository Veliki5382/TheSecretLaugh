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

    private float startCD;
    private float startCD1;
    bool bioPrvi;

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
            print(wanted);
        }
        osmeh.sprite = smileSprite[(int)wanted.x];
    }
}
