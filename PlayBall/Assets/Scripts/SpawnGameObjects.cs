using UnityEngine;
using System.Collections;

public class SpawnGameObjects : MonoBehaviour
{
	public float secondsBetweenSpawning = 0.1f; //времени между спавном
	//район спавна
	public float xMinRange = -25.0f;
	public float xMaxRange = 25.0f;
	public float yMinRange = 8.0f;
	public float yMaxRange = 25.0f;
	public GameObject[] spawnObjects; // массив объектов для спавна

	private float nextSpawnTime;

	
	void Start ()
	{
		// назначение времени следующего спавна
		nextSpawnTime = Time.time+secondsBetweenSpawning;
	}
	
	
	void Update ()
	{
    	// если пора спавнить новый объект
		if (Time.time  >= nextSpawnTime) {
			// то спавним объект
			MakeThingToSpawn ();

			// назначаем новое время слудющего спавна
			nextSpawnTime = Time.time+secondsBetweenSpawning;
		}	
	}

	void MakeThingToSpawn ()
	{
		//три позиции для спавна
		Vector2 spawnPosition;
		Vector2 spawnPosition1;
		Vector2 spawnPosition2;

		// назначение 3 радомных мест для спавна
		spawnPosition.x = Random.Range (xMinRange, xMaxRange);
		spawnPosition.y = Random.Range (yMinRange, yMaxRange);

		spawnPosition1.x = Random.Range (xMinRange, xMaxRange);
		spawnPosition1.y = Random.Range (yMinRange, yMaxRange);
		
		spawnPosition2.x = Random.Range (xMinRange, xMaxRange);
		spawnPosition2.y = Random.Range (yMinRange, yMaxRange);

		// случайные объекты для спавна
		int objectToSpawn = Random.Range (0, spawnObjects.Length);
		int objectToSpawn1 = Random.Range (0, spawnObjects.Length);
		int objectToSpawn2 = Random.Range (0, spawnObjects.Length);

		//выбор, сколько объектов спавнить
		int i = Random.Range(0,3);

		// спавн 1, 2 или 3 объектов
		if (i == 0)
		{
			GameObject spawnedObject = Instantiate (spawnObjects [objectToSpawn], spawnPosition, transform.rotation) as GameObject;
		}
		else if (i == 1)
		{
			GameObject spawnedObject = Instantiate (spawnObjects [objectToSpawn], spawnPosition, transform.rotation) as GameObject;
			GameObject spawnedObject1 = Instantiate (spawnObjects [objectToSpawn1], spawnPosition1, transform.rotation) as GameObject;
		}
		else if (i == 2)
		{
			GameObject spawnedObject = Instantiate (spawnObjects [objectToSpawn], spawnPosition, transform.rotation) as GameObject;
			GameObject spawnedObject1 = Instantiate (spawnObjects [objectToSpawn1], spawnPosition1, transform.rotation) as GameObject;
			GameObject spawnedObject2 = Instantiate (spawnObjects [objectToSpawn2], spawnPosition2, transform.rotation) as GameObject;
		}
	}
}
