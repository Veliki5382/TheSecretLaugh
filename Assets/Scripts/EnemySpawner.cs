using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	public GameObject player;
	public GameObject enemy;
	public Vector3[] lowerSpawner;
	public Vector3[] upperSpawner;

    // Start is called before the first frame update
    void Start()
    {
        lowerSpawner = new Vector3[3];
		lowerSpawner[0] = new Vector3(1.9f, -1.19f, 2f);
		lowerSpawner[1] = new Vector3(-17.48f, 7.86f, 2f);
		lowerSpawner[2] = new Vector3(18f, 1.05f, 2f);

		upperSpawner = new Vector3[3];
		upperSpawner[0] = new Vector3(16.12f, 32.2f, 2f);
		upperSpawner[1] = new Vector3(-4.5f, 36.16f, 2f);
		upperSpawner[2] = new Vector3(-19f, 27.95f, 2f);

		player = GameObject.FindWithTag("Player");
	}

	public void Spawn()
	{
		if (player.transform.position.y <= 18)
		{
			Instantiate(enemy, new Vector3(3, 3, 3), Quaternion.identity);
			//Instantiate(enemy, lowerSpawner[Random.Range(0, 2)], Quaternion.identity);
		}
		else
		{
			Instantiate(enemy, upperSpawner[Random.Range(0, 2)], Quaternion.identity);
		}
	}

	// Update is called once per frame
	void Update()
    {
        
    }
}
