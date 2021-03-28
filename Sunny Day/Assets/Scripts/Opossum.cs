using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opossum : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1.2f; //переменная скорости движения врага
    [SerializeField] private Transform[] wayPoints; //массив точек для перемещения
    [SerializeField] public int index; //к какой точке он сейчас идет

    [SerializeField] private float rotSpeed; //скорость поворота
    public bool isTurn; 

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, wayPoints[index].position, moveSpeed * Time.deltaTime); //движение к целевой точке

        if (isTurn)
            TurnRotation(); //поворот

        if (Vector2.Distance(transform.position, wayPoints[index].position) <= 0.05f)//обновление целевой точки, при достижениии предыдущей
        {
            index++;
            isTurn = true;
            if (index > wayPoints.Length - 1) {
                index = 0;
            }
        }

        if (index == 1)
        {
            transform.localScale = new Vector3(-3,3,1);
        }
        else
        {
            transform.localScale = new Vector3(3,3,1);
        }
    }

    //функция поворота
    private void TurnRotation()
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, wayPoints[index].rotation, rotSpeed * Time.deltaTime);
    }
}
