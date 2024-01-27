using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HighScoreText : MonoBehaviour
{
    public TextMeshProUGUI highscoretext;
    void Start()
    {
        highscoretext.text = $"HIGH SCORE: {PlayerPrefs.GetInt("HighScore", 0)}";
    }
}
