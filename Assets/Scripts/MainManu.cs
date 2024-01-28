using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    void Start()
    {
        Player.score = 0;
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Play();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Quit();
        }
    }
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void Quit()
    {
        Application.Quit();
    }
}
