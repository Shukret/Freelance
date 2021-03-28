using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    [SerializeField] private float speed; //скорость передвижения
    [SerializeField] private player playerScript; //скрипт игрока
    [SerializeField] private Vector3 target; //точка назначения
    // Start is called before the first frame update
    void Start()
    {
        //заполнение переменной скрипта игрока при спавне
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<player>();
        //движение в рандомную точку одной из 4 сторон экрана
        int i = Random.Range(0,4);
		if (i == 0)
		{
			target = new Vector3(playerScript.left_bottom.x-5, Random.Range(playerScript.right_bottom.y, playerScript.right_top.y));
		}
		else if (i==1)
		{
			target = new Vector3(playerScript.right_bottom.x+5, Random.Range(playerScript.right_bottom.y, playerScript.right_top.y));
		}
		else if (i==2)
		{
			target = new Vector3(Random.Range(playerScript.left_bottom.x, playerScript.right_bottom.x), playerScript.right_bottom.y-5);
		}
		else
		{
			target = new Vector3(Random.Range(playerScript.left_bottom.x, playerScript.right_bottom.x), playerScript.right_top.y+5);
		}
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, target, speed * Time.deltaTime); //движение к целевой рандомной точке
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //выход за зону экрана 
        if(other.CompareTag("death"))
        {
            Destroy(gameObject); //уничтожение объекта
        }
    }
}
