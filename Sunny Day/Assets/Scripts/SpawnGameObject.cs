using UnityEngine;
using System.Collections;

public class SpawnGameObject : MonoBehaviour
{
	public float secondsBetweenSpawning = 0.1f; //интервал спавна
	//район спавна 
	public float xMinRange = -25.0f; 
	public float xMaxRange = 25.0f;  
	public float yMinRange = 8.0f;   
	public float yMaxRange = 25.0f;
	public GameObject[] spawnObjects; // массив префабов для спавна

	private float nextSpawnTime;

	void Start ()
	{
		// вычиление времени, когда спавнить в следующий раз
		nextSpawnTime = Time.time+secondsBetweenSpawning;
	}
	
	void Update ()
	{

		// если пора спавнить новый объект
		if (Time.time  >= nextSpawnTime) {
			// выполняем функцию для спавна
			MakeThingToSpawn ();

			// и снова пересчитываем время
			nextSpawnTime = Time.time+secondsBetweenSpawning;
		}	
	}

	void MakeThingToSpawn ()
	{
		Vector2 spawnPosition;

		// определяем позицию для спавна
		spawnPosition.x = Random.Range (xMinRange, xMaxRange);
		spawnPosition.y = Random.Range (yMinRange, yMaxRange);

		// выбираем случайный объект
		int objectToSpawn = Random.Range (0, spawnObjects.Length);

		// спавним его 
		GameObject spawnedObject = Instantiate (spawnObjects [objectToSpawn], spawnPosition, transform.rotation) as GameObject;

		// делаем его дочерним объектом
		spawnedObject.transform.parent = gameObject.transform;
	}
}
