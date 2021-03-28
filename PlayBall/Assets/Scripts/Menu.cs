using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public static int firstStart = 0; //проверка на первый запуск игры
    public static string name; //имя игрока
    [SerializeField] private GameObject SettingsPanel; //панель настроек
    [SerializeField] private GameObject FirstPanel; //панель первого приветствия
    [SerializeField] private InputField inf; //поле для ввода имени 

    [SerializeField] private SaveSystem save; //скрипт сохранения игры
    
    void Start()
    {
        save.LoadGame(); //загрузка сохарненных ранее данныз
        //если запуск не первый, выключить панель приветствия
        if (firstStart == 1)
        {
            FirstPanel.SetActive(false);
        }
    }

    //кнопка старта игры
    public void StartBtn()
    {
        SceneManager.LoadScene("Game");
    }

    //кнопка включения настроек
    public void SettingsPanelOn()
    {
        SettingsPanel.SetActive(true);
    }

    //кнопка выключения настроек
    public void SettingsPanelOff()
    {
        SettingsPanel.SetActive(false);
    }

    //кнопка рестарта игры
    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }

    //кнопка начала игры на панели приветствия
    public void FirstStartBtn()
    {
        //если текст имени заполнен
        if (!string.IsNullOrEmpty(inf.text))
        {
            FirstPanel.SetActive(false); //отключить панель приветствия
            name = inf.text; //запомнить введенное имя
            firstStart = 1; //запомнить, что первый запуск уже был
            save.SaveGame(); //сохранить данные
        }
    }

    //кнопка показа лидерборда
    public void ShowLeaderBoard()
    {
        Social.ShowLeaderboardUI();
    }
}
