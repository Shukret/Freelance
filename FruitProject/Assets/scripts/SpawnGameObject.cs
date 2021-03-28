using UnityEngine;
using System.Collections;

public class SpawnGameObject : MonoBehaviour
{
	[SerializeField] private player playerScript; //переменная для скрипта игрока
	public float secondsBetweenSpawning = 0.1f; //время между спавном
	//задача района спавна
	public float xMinRange = -25.0f;
	public float xMaxRange = 25.0f;
	public float yMinRange = 8.0f;
	public float yMaxRange = 25.0f;
	public GameObject[] spawnObjects; // массив префабов для спавна

	private float nextSpawnTime;

    void Start()
    {
		// задача времени следующего спавна
		nextSpawnTime = Time.time+secondsBetweenSpawning;
    }
	
	void Update ()
	{
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
		//создание 4 рандомных мест для спавна 
		Vector2 spawnPosition1 = new Vector2(playerScript.left_bottom.x, Random.Range (playerScript.left_bottom.y, playerScript.left_top.y));
		Vector2 spawnPosition2;
		Vector2 spawnPosition3;
		Vector2 spawnPosition4;

		spawnPosition2.x = playerScript.right_bottom.x;
		spawnPosition2.y = Random.Range (playerScript.right_bottom.y, playerScript.right_top.y);

		spawnPosition3.x = Random.Range (playerScript.left_bottom.x, playerScript.right_bottom.x);
		spawnPosition3.y = playerScript.left_bottom.y;

		spawnPosition4.x = Random.Range (playerScript.left_bottom.x, playerScript.right_bottom.x);
		spawnPosition4.y = playerScript.left_top.y;
		
		//выбор одного из них
		int i = Random.Range(0,4);
		// выбор префаба для спавна
		int objectToSpawn = Random.Range (0, spawnObjects.Length);
		//спавн выбранного префаба в определенной точке
		if (i == 0)
		{
			GameObject spawnedObject = Instantiate (spawnObjects [objectToSpawn], spawnPosition1, transform.rotation) as GameObject;
		}
		else if (i==1)
		{
			GameObject spawnedObject = Instantiate (spawnObjects [objectToSpawn], spawnPosition2, transform.rotation) as GameObject;
		}
		else if (i==2)
		{
			GameObject spawnedObject = Instantiate (spawnObjects [objectToSpawn], spawnPosition3, transform.rotation) as GameObject;
		}
		else
		{
			GameObject spawnedObject = Instantiate (spawnObjects [objectToSpawn], spawnPosition4, transform.rotation) as GameObject;
		}
	}
}
