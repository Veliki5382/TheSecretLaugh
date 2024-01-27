using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoretext;
    void Start()
    {
        scoretext.text = $"SCORE: {Player.score}";
    }
}
