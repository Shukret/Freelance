using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamesButtons : MonoBehaviour
{   
    [SerializeField] private Sprite on; //спрайт включенной музыки
    [SerializeField] private Sprite off; //спрайт выключенной музыки
    [SerializeField] private Image img; //изображение кнопки музыки

    [SerializeField] private AudioSource audio; //компонент музыки
    [SerializeField] private bool active; //включена или выключена музыкы
    [SerializeField] private GameObject buttonPause; //кнопка паузы

    //кнопка включения/выключения музыки
    public void MusicBtn()
    {
        //выключение
        if (active)
        {
            audio.volume = 0;
            active = false;
            img.sprite = off;
        }
        //включение
        else if(!active)
        {
            audio.volume = 100;
            active = true;
            img.sprite = on;
        }
    }

    //включение паузы
    public void PauseOn()
    {
        buttonPause.SetActive(true); //включение панели паузы
        Time.timeScale = 0; //остановка игры
    }

    //выключение паузы
    public void BtnPause()
    {
        buttonPause.SetActive(false); //выключение панели паузы
        Time.timeScale = 1; //продолжение игры
    }
}
