using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    [SerializeField] private player playerScript; //скрипт игрока
    [SerializeField] private Text timerText; //отображение времени текстом
    int time; //количество времени

    void Start()
    {
        //обнуление времени и старт таймера
        time = 0;
        InvokeRepeating("Timer", 1,1);
    }

    // Update is called once per frame
    void Update()
    {
        timerText.text = time.ToString(); //отображение времени текстом
        //если игра окончена - просчитываем лучшие результаты
        if (playerScript.game == false)
        {
            for(int i = 0; i < 3; i++)
            {
                if (time > results.best[i])
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
                    results.best[i] = time;
                    break;
                }
            }
            //загружаем сцену меню
            SceneManager.LoadScene("menu");
        }
    }

    //функция убавления времени
    void Timer()
    {
        time += 1;
    }
}
