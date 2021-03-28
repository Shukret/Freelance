using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;
using MoreMountains.NiceVibrations;

public class playerController : MonoBehaviour
{
    [SerializeField] private GameObject shareBtn;
    [SerializeField] private GameObject leadBtn;
    [SerializeField] private AudioSource lose;
    public static int death;
    [SerializeField] private MobAdsSimple ad;
    [Header("Cups")]
    [SerializeField] private Text meText;
    [SerializeField] private GameObject enPanel;
    int battleNumber;
    [SerializeField] private Text titleText;
    [SerializeField] private Text cupsText;
    [SerializeField] private int cups;
    [Header("WinOrLose")]
    [SerializeField] private bool win = false;
    public static int mult = 0;
    int startGame;
    [Header("ruchka")]
    [SerializeField] private float angleRuchkaRight;
    [SerializeField] private float angleRuchkaLeft;
    [SerializeField] private GameObject ruchkaGFX;
    [SerializeField] private Animator anim;
    [Header("Move")]
    [SerializeField] private float speed;
    [SerializeField] private GameObject gfx;
    bool down;
    bool up;
    [Header("points")]
    public static int maxPoints;
    public static int points;
    [SerializeField] private Text pointsText;
    [SerializeField] private Text pointsResText;
    [SerializeField] private Text pointsTitleText;
    [SerializeField] private Text pointsTitleGameText;
    [SerializeField] private Text toMenuText;
    [SerializeField] private Text retryText;
    [Header("live")]
    [SerializeField] private bool live;
    [SerializeField] private GameObject deathPanel;
    [SerializeField] private Sprite pauseOn;
    [SerializeField] private Sprite pauseOff;
    [SerializeField] private Image pauseImg;
    [Header("pause")]
    [SerializeField] private bool pause;
    [Header("ad")]
    [SerializeField] private const string leaderboard = "CgkIlMHuubcREAIQAQ";
    // Start is called before the first frame update
    void Start()
    {
        meText.text = "Me\n" + maxPoints.ToString(); // отображение рекорда
        battleNumber = PlayerPrefs.GetInt("battleNumber"); //подгрузка количества игр в мультиплеере
        startGame = PlayerPrefs.GetInt("startGame"); //количество запущенных игр
        if (startGame >= 5) //если запущенных игр больше 4
        { 
            //активируем мультиплеер
            mult = 1;
            PlayerPrefs.SetInt("mult", mult);
        }
        points = 0; //обнуляем очки
        pause = false; //убираем паузу
        Time.timeScale = 1; //начинаем игру
        live = true; //играем
        StartCoroutine(PlusPoints()); //прибавляем очки
        if (mult == 1) //если мультиплеер
        { //выключаем кнопки "поделиться" и "лидерборд" в панели смерти
            shareBtn.SetActive(false);
            leadBtn.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //назначаем тексты в зависимости от перевода
        if (Menu.language == "english")
        {
            pointsTitleGameText.text = "Points:"; 
            toMenuText.text = "Menu";
        }
        else if (Menu.language == "russian")
        {
            pointsTitleGameText.text = "Очки:";
            toMenuText.text = "Меню";
            retryText.text = "Переиграть";
        }
        pointsText.text = points.ToString(); //показываем количество очков
        //двигаемся вверх       
        if (up)
        {
            transform.Translate(Vector3.up * speed*Time.deltaTime);
        }
        //двигаемся вниз
        if (down)
        {
            transform.Translate(Vector3.down *speed*Time.deltaTime);
        }
    }

    //кнопки движения
    public void UpBtn()
    {
        anim.SetInteger("ang",1);
        gfx.transform.rotation = Quaternion.Euler(0,0,45);
        up = true;
    }

    public void DownBtn()
    {
        anim.SetInteger("ang",-1);
        gfx.transform.rotation = Quaternion.Euler(0,0,-45);
        down = true;
    }
    //кнопка выравнивания
    public void StatBtn()
    {
        anim.SetInteger("ang",0);
        gfx.transform.rotation = Quaternion.Euler(0,0,0);
        up = false;
        down = false;
    }

    //корутина прибавления очков каждую секунду
    IEnumerator PlusPoints()
    {
        while (live)
        {
            yield return new WaitForSeconds(1);
            points += 1;
        }
    }


    //функции для кнопок сцены
    //кнопка проигрыша - загрузки сцены меню или рестарта
    public void DeathBtn(string scene)
    {
        if (scene == "Game")
        {
            Menu.toMult -= 1;
            PlayerPrefs.SetInt("toMult", Menu.toMult);
            startGame = PlayerPrefs.GetInt("startGame");
            playerController.mult = PlayerPrefs.GetInt("mult");
            startGame += 1;
            PlayerPrefs.SetInt("startGame", startGame);
        }
        SceneManager.LoadScene(scene);
    }

    //кнопка паузы
    public void PauseBtn()
    {
        if (pause)
        {
            pause = false;
            Time.timeScale = 1;
            pauseImg.sprite = pauseOff;
        }
        else if (!pause)
        {
            pause = true;
            Time.timeScale = 0;
            pauseImg.sprite = pauseOn;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {   
        //при соприкосновении с врагом
        if (other.CompareTag("enemy"))
        {
            //показ рекламы каждую 5 смерть
            death+=1;
            if (death==5)
            {
                death = 0;
                ad.ShowAd();
            }
            //если был онлайн
            if (mult==1)
            {
                //прибавляем номер битвы
                battleNumber += 1;
                //сохраняем его
                PlayerPrefs.SetInt("battleNumber", battleNumber);
                //определяем, выиграл игрок дуэль или проиграл
                if (points >= NextEnemy.enPoints)
                {
                    win = true;
                }
                else
                {
                    win = false;
                }
                //если выиграл, прибавляем кубки по формуле
                if (win)
                {
                    if (maxPoints - NextEnemy.enPoints > 20)
                    {
                        cups = +10;
                    }
                    else if(maxPoints - NextEnemy.enPoints > 10)
                    {
                        cups = +9;
                    }
                    else
                    {
                        cups = +8; 
                    }
                }
                //если проиграл, убавляем их по той же системе
                else
                {
                    if (battleNumber >= 5)
                    {
                        if (NextEnemy.enPoints - maxPoints > 20)
                        {
                            cups = -8;
                        }
                        else if(NextEnemy.enPoints - maxPoints > 10)
                        {
                            cups = -9;
                        }   
                        else
                        {
                            cups = -10;
                        }
                    }
                    else
                    {
                        cups = -0;
                    }
                }
            }
            //установление рекорда
            if (points >= maxPoints)
            {
                maxPoints = points;
            }
            //вибрация
            MMVibrationManager.Haptic (HapticTypes.Failure);
            //рекорд
            PlayerPrefs.SetInt("maxPoints", maxPoints);
            //игровая смерть
            live = false;
            deathPanel.SetActive(true);
            Time.timeScale = 0;
            lose.Play();
            //тексты   
            if (mult==1)      
            {
                if (cups > 0)
                {
                    titleText.text = "You win with score";
                    cupsText.text = "+" + cups.ToString();
                }
                else
                {
                    if (cups == 0)
                    {
                        cupsText.text = "-" + cups.ToString();
                    }
                    else
                    {
                        cupsText.text = cups.ToString();
                    }
                    titleText.text = "You lose with score";
                }
            }
            pointsResText.text = points.ToString();

            if(mult==1)
            {
                Menu.cup += cups;
                enPanel.SetActive(true);
            }
        }
    }
}
