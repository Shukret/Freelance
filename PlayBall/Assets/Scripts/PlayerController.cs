using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;
using GoogleMobileAds.Api;

public class PlayerController : MonoBehaviour
{
    bool dea;
    [SerializeField] private MobAdsSimple ads;


    [SerializeField] private Text record;
    [SerializeField] private Button finalButton;
    bool win = false;
    [SerializeField] private Text pointsText;
    [SerializeField] private GameObject stopPanel;
    [SerializeField] private Text nikText;
    int points;
    bool canGame;
    [Header("Behavior")]
    public float JumpPower = 0.25f;
    public float MaxJumpTime = 0.25f;

    private float _StoreMaxTime;
    private bool jumping = false;
    private Rigidbody2D rb;

    bool jump = false;

    [Header("Очки за ромбы")]
    [SerializeField] private int pointsGreen;
    [SerializeField] private int pointsRed;
    [SerializeField] private int pointsBlue;
    
    [Header("Тексты очков за ромбы")]
    [SerializeField] private Text greenText;
    [SerializeField] private Text redText;
    [SerializeField] private Text blueText;

    [Header("Собрано ромбов")]
    [SerializeField] private int takeGreen;
    [SerializeField] private int takeRed;
    [SerializeField] private int takeBlue;

    [Header("Поражение")]
    [SerializeField] private Text takeGreenText;
    [SerializeField] private Text takeRedText;
    [SerializeField] private Text takeBlueText;
    [SerializeField] private Text finishPointText;
    [SerializeField] private TextMesh nikGameText;
    [SerializeField] private Text codeText;
    [SerializeField] private GameObject retryButton;

    [Header("Реклама")]
    [SerializeField] private const string leaderboard = "CgkIpfHkzroREAIQAQ";
    public static int deathNumber;
    private InterstitialAd interstitialAd;
    private string appID, interstitialAdID;
    bool recordShow;

    int number;
    char letter;


    void Start () 
    {
        //Рейтинг
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
        //назначить текст имени
        nikGameText.text = Menu.name;
        //обнулить количество подобранных алмазов
        takeGreen = 0;
        takeBlue = 0;
        takeRed = 0;
        //назначение текстов с баллами за алмазы
        greenText.text = pointsGreen.ToString();
        redText.text = pointsRed.ToString();
        blueText.text = pointsBlue.ToString();
        //прибавление очков каждую секунду
        InvokeRepeating("PointsPlus", 1, 1);
        //играть можем
        canGame = true;
        //назначение переменной rb
        rb = GetComponent<Rigidbody2D>();
        _StoreMaxTime = MaxJumpTime;
    }
    
    void PointsPlus()
    {
        points += 1; //прибавляем очки
        Social.ReportScore(points, leaderboard, (bool success) => { }); //отображаем очки в лидерборде
    }

    //функция показа лидерборда
    public void ShowLeaderBoard()
    {
        Social.ShowLeaderboardUI();
    }

    //функция выхода из лидерборда
    public void ExitFromGPS()
    {
        PlayGamesPlatform.Instance.SignOut();
    }

    void Update () 
    {
        //показ количества очков
        pointsText.text = points.ToString();
        //если игрок не проиграл
        if (canGame)
        {
            //если может прыгнуть
           if (jump)
            {
                //выполнение прыжка
                MaxJumpTime -= Time.deltaTime;
                rb.AddForce(new Vector2(0, JumpPower),ForceMode2D.Impulse);
            }
        }
        else
        {
            //падение
            rb.AddForce(new Vector2(0, -JumpPower),ForceMode2D.Impulse);
        }
    }

    //нажатие на кнопку прыжка
    public void Down()
    {
        MaxJumpTime = _StoreMaxTime;
        jump = true;
    }
    //поднятие пальца с кнопки прыжка
    public void Up()
    {
        MaxJumpTime = -1;
        jump = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //проигрыш при столкновении с врагом или вылетом за экран
        if (other.CompareTag("enemy") || other.CompareTag("death"))
        {
            canGame = false;
            StartCoroutine(stopGame());
        }
        //прибавление очков за определенный подобранный кристалл
        if (other.CompareTag("green"))
        {
            takeGreen += 1;
            Destroy(other.gameObject);
        }
        if (other.CompareTag("red"))
        {
            takeRed += 1;
            Destroy(other.gameObject);
        }
        if (other.CompareTag("blue"))
        {
            takeBlue += 1;
            Destroy(other.gameObject);
        }
    }

    //корутина остановки игры при проигрыше
    IEnumerator stopGame()
    {
        //показ рекламы AdMob при каждом пятом проигрыше
        if (dea == false)
        {
            dea = true;
            deathNumber += 1;
            Debug.Log(deathNumber);
            if (deathNumber == 5)
            {
                ads.ShowAd();
                deathNumber = 0;
            }
        }
        yield return new WaitForSeconds(1);
        Finish(); //выполнение последних подсчетов после проигрыша
        dea = false;
        stopPanel.SetActive(true); //включение панели проигрыша
    }

    void Finish()
    {
        //сохранить количество очков
        int finishPoint = points;
        //отобразить тексты подобранных кристаллов
        takeGreenText.text = takeGreen.ToString();
        takeRedText.text = takeRed.ToString();
        takeBlueText.text = takeBlue.ToString();
        //отобразить ник
        nikText.text = Menu.name;
        //отобразить количество очков
        finishPointText.text = finishPoint.ToString();
        if (!win)
        {
            finalButton.enabled = false;
            retryButton.SetActive(true);
            codeText.text = null;
        }
    }
}
