using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePrefs : MonoBehaviour
{
    void Start()
    {
        LoadGame();//загрузка сохраненных данных
    }

    void Update()
    {
        SaveGame();//сохранение данных
    }
    
    void SaveGame()
    {
        PlayerPrefs.SetInt("SavedInteger", PurchaseGame.ads);  //сохранение подписки
        PlayerPrefs.SetInt("SaveInteger", PlayerController.gems);  //сохранение кристаллов
        PlayerPrefs.SetInt("FirstTime", TimeSystem.firstTime);  //сохранение заходов в игру
        PlayerPrefs.Save();
    }

    void LoadGame()
    {
    if (PlayerPrefs.HasKey("SavedInteger"))
        {
            PurchaseGame.ads = PlayerPrefs.GetInt("SavedInteger"); //загрузка данных о подписке
            PlayerController.gems = PlayerPrefs.GetInt("SaveInteger"); //загрузка кристаллов
            PlayerPrefs.SetInt("FirstTime", TimeSystem.firstTime);   //загрузка захода в игру
        }
    }
}
