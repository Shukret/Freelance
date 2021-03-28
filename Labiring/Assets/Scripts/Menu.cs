using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class Menu : MonoBehaviour
{
    [Header("Multiplayer")]
    public static int toMult;
    public int firstG = 0;
    [SerializeField] private GameObject toMultGame;
    [SerializeField] private Text toMultText;
    public static int cup;
    int startGame;
    [SerializeField] private GameObject enemyPanel;
    [SerializeField] private Text meText;
    [SerializeField] private const string leaderboard = "CgkIlMHuubcREAIQAQ";
    [Header("Language")]
    [SerializeField] private Sprite eng;
    [SerializeField] private Sprite rus;
    [SerializeField] private Image langImg;
    [SerializeField] private Text clickText;
    public static string language = "english";
    
    //кнопка старта игры
    public void StartBtn()
    {
        toMult -= 1; //убалвяем 1 попытку до мультиплеера
        PlayerPrefs.SetInt("toMult", toMult); //сохраняем оставшееся количество
        startGame = PlayerPrefs.GetInt("startGame"); //подгружаем количество запущенных игр
        playerController.mult = PlayerPrefs.GetInt("mult"); //загружаем, активирован ли мультиплеер
        startGame += 1; //прибавляем количество запусков игры
        PlayerPrefs.SetInt("startGame", startGame); //сохраняем количество запусков игры
        SceneManager.LoadScene("Game"); //включаем сцену Game
    }
    //функция очистки всех сохранений
    public void off()
    {
        PlayerPrefs.DeleteAll();
    }
    void Start()
    {
        //загружаем, был ли первый заход в игру
        firstG = PlayerPrefs.GetInt("firstG");
        //если не был
        if (firstG==0)
        {
            toMult = 5;
            firstG = 1;
            PlayerPrefs.SetInt("toMult", toMult);
            PlayerPrefs.SetInt("firstG", firstG);
        }
        //загружаем, сколько осталось до мультиплеера
        toMult = PlayerPrefs.GetInt("toMult");
        //выключаем панель "до мультиплеера", если мультиплеер активирован
        if (playerController.mult == 1)
        {
            toMultGame.SetActive(false);
        }
        //показываем через текст, сколько осталось до мультиплеера
        toMultText.text = toMult.ToString();
        //загружаем, активирован ли мультиплеер
        playerController.mult = PlayerPrefs.GetInt("mult");
        //включаем панель соперничества, если у нас активирован мультиплеер
        if (playerController.mult==1)
        {
            enemyPanel.SetActive(true);
        }
        //загружаем максимальное количество очков
        playerController.maxPoints = PlayerPrefs.GetInt("maxPoints");
        //leaderboard подключение
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();
        Social.localUser.Authenticate(success =>
        {
            if (success)
            {

            }
            else
            {

            }
        });
        //передаем количество очков в лидерборд
        Social.ReportScore(playerController.maxPoints * cup, leaderboard, (bool success) => { });
        //показываем свой рекорд
        meText.text = "Me\n" + playerController.maxPoints.ToString();
        //off();
    }

    void Update()
    {
        //у кубков не может быть отрицательного значения
        if (cup < 0)
        {
            cup = 0;
        }
        if (language == "english")
        {
            clickText.text = "Click for start game";
            clickText.fontSize = 58;
        }
        else if (language == "russian")
        {
            clickText.text = "Нажми для старта игры";
            clickText.fontSize = 41;
        }
    }

    //функция показа лидерборда
    public void ShowLeaderboard()
    {
        Social.ShowLeaderboardUI();
    }

    //функция выхода из лидерборда
    public void ExitFromGPS()
    {
        PlayGamesPlatform.Instance.SignOut();
    }
}
