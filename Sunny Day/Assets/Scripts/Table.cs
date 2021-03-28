using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    [SerializeField] private GameObject tutorialRussianPanel; //изображение таблички туториала на русском
    [SerializeField] private GameObject tutorialEnglishPanel; //на английском

    void Start()
    {
        //отключение обеих панелей туториала
        tutorialRussianPanel.SetActive(false); 
        tutorialEnglishPanel.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //столкновение с панелью и ее включение
        if (other.CompareTag("Player"))
        {
            if(Menu.language == "english")
                tutorialEnglishPanel.SetActive(true);
            else if (Menu.language == "русский")
                tutorialRussianPanel.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        //выход из зоны включения туториала
        if (other.CompareTag("Player"))
        {
            tutorialEnglishPanel.SetActive(false);
            tutorialRussianPanel.SetActive(false);
        }
    }
}
