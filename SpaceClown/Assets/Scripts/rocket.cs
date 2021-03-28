using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class rocket : MonoBehaviour
{
    [SerializeField] private player playerScript; //скрипт игрока
    int coins; //количество собранных монет
    [SerializeField] private Text coinsText; //текст для отображения количества монет
    [SerializeField] private AudioSource coinSound; //звук подбора монетки
    void Start()
    {
        aSpeed.mult = 2; //задание стартового значения множителя
        coins = 0; //обнуление монет
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        //прикосновение с монеткой
        if (other.CompareTag("coin"))
        {
            coinSound.Play(); //играем звук
            coins += 1; //прибавляем очки
            Destroy(other.gameObject); //уничтожаем монетку
        }
        //столкновение с астероидом
        if (other.CompareTag("asteroid"))
        {
            playerScript.game = false; //игра окончена
        }
    }
    void Update()
    {
        coinsText.text = coins.ToString(); //отображаем количество очков в тексте
        //если игра окончена
        if (playerScript.game == false)
        {
            //цикл просчета лучших результатов
            for(int i = 0; i < 3; i++)
            {
                if (coins > results.best[i])
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
                    results.best[i] = coins;
                    break;
                }
            }
            //загружаем сцену меню
            SceneManager.LoadScene("menu");
        }
    }
}
