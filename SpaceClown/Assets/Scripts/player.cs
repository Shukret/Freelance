using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class player : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    public Transform Player; //позиция игрока
    public bool game; //живы мы или нет
    public int line; //номер линии, в которой находится ракета

    //функция свайпа
    public void OnBeginDrag(PointerEventData eventData)
    {
        //если свайпнули
        if (Mathf.Abs(eventData.delta.x) > Mathf.Abs(eventData.delta.y))
        {
            //определение стороны свайпа
            //если вправо и мы в центральной или левой линии
            if (eventData.delta.x > 0 && line <= 0)
            {
                //перемещаем игрока в правую линию
                Player.position += Vector3.right * 2;
                line += 1;
            }
            //если влево и мы в центральной или правой линии
            else if(eventData.delta.x < 0 && line >= 0)
            {
                //перемещаем игрока в левую линию
                Player.position += Vector3.left * 2;
                line -=1;
            }
        }
    }

    //функция для свайпа
    public void OnDrag(PointerEventData eventData)
    {

    }

    void Start()
    {
        //задание центральной линии и старт игры
        line = 0;
        game = true;
    }


    void Update()
    {
        
    }
}
