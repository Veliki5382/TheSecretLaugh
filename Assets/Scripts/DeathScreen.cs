using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DeathScreen : MonoBehaviour
{
    public GameObject game;
    public GameObject ostalo;
    public void TryAgain()
    {
        gameObject.SetActive(false);
        game.SetActive(true);
        ostalo.SetActive(true);
        SceneManager.LoadScene(1);
        Player.score = 0;
    }

    public void BacktoManu()
    {
        SceneManager.LoadScene(0);
    }
}
