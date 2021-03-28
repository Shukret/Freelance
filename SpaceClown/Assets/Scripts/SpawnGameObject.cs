using UnityEngine;
using System.Collections;

public class SpawnGameObject : MonoBehaviour
{
	public float firstTime;
	public float secondTime;
	public float thirdTime;
	public float secondsBetweenSpawning = 0.1f; //переменная для скрипта игрока
	//позиции для спавна
	[SerializeField] private Transform spawn;
	[SerializeField] private Transform spawn1;
	[SerializeField] private Transform spawn2;
	public GameObject[] spawnObjects; // массив префабов для спавна

	[SerializeField] private GameObject coinPrefab;

	private float nextSpawnTime;

    void Start()
    {
		//первый спавн
		secondsBetweenSpawning = firstTime;
		MakeThingToSpawn ();
		// задача времени следующего спавна
		nextSpawnTime = Time.time+secondsBetweenSpawning;
    }
	
	// Update is called once per frame
	void Update ()
	{
		if (aSpeed.mult >= 4 && aSpeed.mult < 10)
		{
			secondsBetweenSpawning = secondTime;
		}
		else if(aSpeed.mult >= 10)
		{
			secondsBetweenSpawning = thirdTime;
		}
		// если настало время для нового спавна
		if (Time.time  >= nextSpawnTime) {
			// выполнить функцию спавна
			MakeThingToSpawn ();

			// задача нового времени следующего спавна
			nextSpawnTime = Time.time+secondsBetweenSpawning;
		}	
	}

	void MakeThingToSpawn ()
	{
		//выбор рандомных мест для спавна и объектов для спавна
		int i = Random.Range(0,2);
		int j = Random.Range(0,3);
		int objectToSpawn = Random.Range (0, spawnObjects.Length);
		int objectToSpawn2 = Random.Range (0, spawnObjects.Length);
		
		//в пустые места спавнятся монетки
		//спавнится 1 метеорит
		if (i == 0)
		{
			if (j==0)
			{
				GameObject spawnedObject1 = Instantiate (spawnObjects [objectToSpawn], spawn.position, transform.rotation) as GameObject;
				GameObject spawnedObject2 = Instantiate (coinPrefab, spawn1.position, transform.rotation) as GameObject;
				GameObject spawnedObject3 = Instantiate (coinPrefab, spawn2.position, transform.rotation) as GameObject;
			}
			if (j==1)
			{
				GameObject spawnedObject1 = Instantiate (spawnObjects [objectToSpawn], spawn1.position, transform.rotation) as GameObject;
				GameObject spawnedObject2 = Instantiate (coinPrefab, spawn.position, transform.rotation) as GameObject;
				GameObject spawnedObject3 = Instantiate (coinPrefab, spawn2.position, transform.rotation) as GameObject;
			}
			if (j==2)
			{
				GameObject spawnedObject1 = Instantiate (spawnObjects [objectToSpawn], spawn2.position, transform.rotation) as GameObject;
				GameObject spawnedObject2 = Instantiate (coinPrefab, spawn1.position, transform.rotation) as GameObject;
				GameObject spawnedObject3 = Instantiate (coinPrefab, spawn.position, transform.rotation) as GameObject;
			}
		}

		//спавнится 2 метеорита
		if (i == 1)
		{
			if (j==0)
			{
				GameObject spawnedObject1 = Instantiate (spawnObjects [objectToSpawn], spawn.position, transform.rotation) as GameObject;
				GameObject spawnedObject2 = Instantiate (spawnObjects [objectToSpawn2], spawn1.position, transform.rotation) as GameObject;
				GameObject spawnedObject3 = Instantiate (coinPrefab, spawn2.position, transform.rotation) as GameObject;
			}
			if (j==1)
			{
				GameObject spawnedObject1 = Instantiate (coinPrefab, spawn.position, transform.rotation) as GameObject;
				GameObject spawnedObject2 = Instantiate (spawnObjects [objectToSpawn], spawn1.position, transform.rotation) as GameObject;
				GameObject spawnedObject3 = Instantiate (spawnObjects [objectToSpawn2], spawn2.position, transform.rotation) as GameObject;
			}
			if (j==2)
			{
				GameObject spawnedObject1 = Instantiate (spawnObjects [objectToSpawn], spawn.position, transform.rotation) as GameObject;
				GameObject spawnedObject2 = Instantiate (coinPrefab, spawn1.position, transform.rotation) as GameObject;
				GameObject spawnedObject3 = Instantiate (spawnObjects [objectToSpawn2], spawn2.position, transform.rotation) as GameObject;
			}
		}
	}
}