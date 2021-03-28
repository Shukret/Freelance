using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    //функция сохранения игровых данных
    public void SaveGame()
    {
        PlayerPrefs.SetString("SaveName", Menu.name);
        PlayerPrefs.SetInt("SaveFirstStart", Menu.firstStart);
        PlayerPrefs.Save();
    }

    //функция загрузки сохраненных данных
    public void LoadGame()
    {
    if (PlayerPrefs.HasKey("SaveName"))
        {
            Menu.name = PlayerPrefs.GetString("SaveName");
            Menu.firstStart = PlayerPrefs.GetInt("SaveFirstStart");
        }
    }
}
