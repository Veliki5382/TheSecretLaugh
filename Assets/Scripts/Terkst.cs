using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tekst : MonoBehaviour
{
    public TextMeshProUGUI tekst;
    void Start()
    {
        if (Player.time <= 0) tekst.text = "TIME'S UP!";
        else tekst.text = "WRONG GUY!";
    }

}
