using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoretext;
    void Start()
    {

    }

    private void Update()
    {
        scoretext.text = $"SCORE: {Player.score}";
    }
}
