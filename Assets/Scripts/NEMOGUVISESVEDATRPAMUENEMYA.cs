using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NEMOGUVISESVEDATRPAMUENEMYA : MonoBehaviour
{
    public static bool[,] killCombination;
    public static int enemyCounter;
    public static int expectedEnemies;
    public GameObject controller;

    public static List<Vector2> list= new List<Vector2>();

    private void Start()
    {
        killCombination = new bool[10, 13];
        enemyCounter = 0;
        expectedEnemies = 3;
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
        list.Clear();
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 13; j++)
            {
                if (killCombination[i, j] == true)
                {
                    list.Add(new Vector2(i, j));
                }
            }
        }
        if (list.Count == 0) return new Vector2(-1, -1);
        else 
        {
            int x = Random.Range(0, list.Count);
            killCombination[(int)list[x].x,(int)list[x].y] = false;
            return list[x]; 
        }
    }
}
