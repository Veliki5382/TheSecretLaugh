using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySpawner : MonoBehaviour
{
	public GameObject enemy;


	// Start is called before the first frame update
	void Start()
	{
		
	}

	public void Spawn()
	{
		if (GameObject.FindWithTag("Player").transform.position.y > 18)
		{
			//Instantiate(enemy, new Vector3(3, 3, 3), Quaternion.identity);
			int randomIndex = Random.Range(0, 2);
			Vector3 spawnPosition = Vector3.zero;
			
			switch (randomIndex)
			{
				default:
					spawnPosition = new Vector3(1.9f, -1.19f, 2f);
					break;
				case 1:
					spawnPosition = new Vector3(-17.48f, 7.86f, 2f);
					break;
				case 2:
					spawnPosition = new Vector3(18f, 1.05f, 2f);
					break;
			}

			Instantiate(enemy, spawnPosition, Quaternion.identity);
		}
		else
		{
			int randomIndex = Random.Range(0, 2);
			Vector3 spawnPosition = Vector3.zero;

			switch (randomIndex)
			{
				default:
					spawnPosition = new Vector3(16.12f, 32.2f, 2f);
					break;
				case 1:
					spawnPosition = new Vector3(-4.5f, 36.16f, 2f);
					break;
				case 2:
					spawnPosition = new Vector3(-19f, 27.95f, 2f);
					break;
			}

			Instantiate(enemy, spawnPosition, Quaternion.identity);
		}
	}

	// Update is called once per frame
	void Update()
	{

	}
}
