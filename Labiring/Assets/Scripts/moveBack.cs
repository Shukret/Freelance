using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBack : MonoBehaviour
{
    [SerializeField] private float speed; //скорость движения
    [SerializeField] private Transform spawnBack; //точка нового спавна
    // Update is called once per frame
    void Update()
    {
        transform.Translate(-speed*Time.deltaTime,0,0); //вычное перемещение влево
        if (transform.position.x < -11)  //если фон ушел слишком влево
        {
            if (spawnBack)
                transform.position = new Vector3(spawnBack.position.x, transform.position.y, transform.position.z); //перемещаем его обратно вправо
        }
    }
}