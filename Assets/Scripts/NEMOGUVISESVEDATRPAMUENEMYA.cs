using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NEMOGUVISESVEDATRPAMUENEMYA : MonoBehaviour
{
    public static bool[,] killCombination;
    public static int enemyCounter;
    public static int expectedEnemies;
    public GameObject controller;

    private void Start()
    {
        killCombination = new bool[10, 13];
        enemyCounter = 0;
        expectedEnemies = 2;
    }

    private void Update()
    {
        if (enemyCounter < expectedEnemies)
        {
            controller.GetComponent<EnemySpawner>().Spawn();
            enemyCounter++;
        }
    }
    public static Vector2 FicaFunkcija()
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 13; j++)
            {
                if (killCombination[i, j] == true)
                {
                    killCombination[i, j] = false;
                    return new Vector2(i, j);
                }
            }
        }
        return new Vector2(-1, -1);
    }
}
