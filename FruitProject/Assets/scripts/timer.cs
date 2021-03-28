using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    public bool game;
    int time;
    [SerializeField] private Text timerText;

    void Start()
    {
        //назначение стартового времени и старта игры
        game = true; 
        time = 60;
        //включение таймера
        InvokeRepeating("Timer", 1,1);
    }

    void Update()
    {
        //текст отображает количество времени
        timerText.text = time.ToString();
        //если время вышло
        if (time <= 0)
        {
            //цикл назначения лучших результатов
            for(int i = 0; i < 3; i++)
            {
                if (player.points > results.best[i])
                {
                    if (i==0)
                    {
                        results.best[2] = results.best[1];
                        results.best[1] = results.best[0];
                    }
                    if (i==1)
                    {
                        results.best[2] = results.best[1];
                    }
                    results.best[i] = player.points;
                    break;
                }
            }
            //конец игры и загрузка сцены меню
            game = false;
            SceneManager.LoadScene("menu");
        }
    }

    //функция убавление времени
    void Timer()
    {
        time -= 1;
    }
}
