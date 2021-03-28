using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ToMenuButton : MonoBehaviour
{
    [SerializeField] private Text buttonText; //текст на кнопке возвращения в меню
    
    //функция для кнопки возвращения в меню
    public void ToMenu_Button()
    {
        SceneManager.LoadScene("Menu");
    }

    //назначение текстов при различных переводах
    void Update()
    {
         if (Menu.language == "english")
            buttonText.text = "To menu";
        else if (Menu.language == "русский")
            buttonText.text = "В меню";
    }
}
