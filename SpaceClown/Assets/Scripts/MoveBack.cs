using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBack : MonoBehaviour
{
    public bool a;
    [SerializeField] private float speed;
    [SerializeField] private float start_speed;
    [SerializeField] private Transform spawn;


    void Start()
    {
        if (a)
            StartCoroutine(Plus());
    }

    //увеличение множителя ускорения
    IEnumerator Plus()
    {
        if (aSpeed.mult < 50)
        {
            aSpeed.mult += 0.1f;
            yield return null;
        }
    }   


    void Update()
    {
        //перемещение влево с заданной скоростью
        gameObject.transform.Translate(0,-aSpeed.mult*Time.deltaTime,0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("stop"))
        {   
            //прикосновение астероида с зоной выхода за экран
            if (gameObject.CompareTag("asteroid"))
            {
                Destroy(gameObject); //уничтожение объекта
            }
            //если задана точка спавна
            if (spawn)
                gameObject.transform.position = new Vector3(spawn.position.x, spawn.position.y, gameObject.transform.position.z); //то переместить объект направо (сделано для движения фона)
        }
    }
}
