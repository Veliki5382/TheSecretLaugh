using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TimeText : MonoBehaviour
{
    public TextMeshProUGUI timescoretext;
    void Start()
    {
        timescoretext.text = $"TIME: {Player.time}";
    }

    private void FixedUpdate()
    {
        if (Player.time <= 10)
        {
            //ckck zvuk
            timescoretext.color = Color.red;
        }
        else timescoretext.color= Color.white;
    }
}
