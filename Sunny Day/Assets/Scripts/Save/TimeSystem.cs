using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimeSystem : MonoBehaviour
{
    [SerializeField] private UnityAdsBanner unityAdsBanner; //рекламный баннер
    public System.DateTime startDate; //время первого захода
    public System.DateTime currentDate;  //нынешнее время
    public static int firstTime = 0;

    TimeSpan ts;  //переменная времени


    void Update()
    {
        if (PlayerPrefs.HasKey("LastSession"))
        {
            ts = currentDate - DateTime.Parse(PlayerPrefs.GetString("LastSession")); //подсчет количества прошедших дней 
        }
        if (ts.Days >= 30) //если дней больше 30 - обнуляем подписку
        {
            Date();
        }

        currentDate = DateTime.Now; //обнуляем стартовое время
    }

    void Date() //функция обнуления подписки
    {
        PurchaseGame.ads = 0;
        firstTime = 1;
        StartCoroutine(unityAdsBanner.ShowBannerWhenReady());
    }
}
