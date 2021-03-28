using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{
    [SerializeField] private Text yesTxt;
    [SerializeField] private Text noTxt;
    [SerializeField] private Text offTxt;


    [SerializeField] private Text GemText;
    [SerializeField] private Text StartGameText;
    [SerializeField] private Text ArcadeText;
    [SerializeField] private Text LanguageText;
    [SerializeField] private Text ExitButtonText;
    public static string language = "english"; //переменная языка игры


    [SerializeField] private GameObject noAdsPanel; //переменная панели отключения рекламы
    

    void Update()
    {
        //переключение языка игры
        if (language == "english")
            GemText.text = "Gems: " + PlayerController.gems;
        else if (language == "русский")
            GemText.text = "Гемов: " + PlayerController.gems;
    }
    void Start()
    {
        //назначение текстам перевода на нужный язык
        if (language == "русский")
        {
            yesTxt.text = "да(149$)";
            noTxt.text = "нет";
            offTxt.text = "Отключить рекламу (30 дней)?";
            StartGameText.text = "Начать игру";
            ArcadeText.text = "Аркада";
            ExitButtonText.text = "Выйти";
        }
        else if (language == "english")
        {
            yesTxt.text = "yes(149$)";
            noTxt.text = "no";
            offTxt.text = "Off ads? (30 days)";
            ArcadeText.text = "Arcade";
            StartGameText.text = "Start game";
            ExitButtonText.text = "Quit";
        }
        LanguageText.text = language;
    }

    //кнопка старта игры
    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }

    //кнопка режима аркады
    public void ArcadeBtn()
    {
        SceneManager.LoadScene("Arcade");
    }

    //кнопка выхода из игры
    public void QuitGame()
    {
        Application.Quit();
    }

    //кнопка смены языка
    public void Language()
    {
        if (language == "english")
        {
            yesTxt.text = "да(149$)";
            noTxt.text = "нет";
            offTxt.text = "Отключить рекламу (30 дней)?";
            language = "русский";
            StartGameText.text = "Начать игру";
             ArcadeText.text = "Аркада";
            ExitButtonText.text = "Выйти";
        }
        else if (language == "русский")
        {
            yesTxt.text = "yes(149$)";
            noTxt.text = "no";
            offTxt.text = "Off ads? (30 days)";
            language = "english";
            ArcadeText.text = "Arcade";
            StartGameText.text = "Start game";
            ExitButtonText.text = "Quit";
        }
        LanguageText.text = language;
    }

    //кнопка включения панели отключения рекламы
    public void NoAdsPanel()
    {
        noAdsPanel.SetActive(true);
    }


    //кнопки NoAdsPanel
    public void Yes()
    {
        noAdsPanel.SetActive(false);
    }

    public void No()
    {
        noAdsPanel.SetActive(false);
    }
}
