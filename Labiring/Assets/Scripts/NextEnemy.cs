using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextEnemy : MonoBehaviour
{
    public static int enPoints;
    //значения
    int enemyCountry;
    string enemyName;
    int enemyPoints;
    public int i;

    [Header("massive")]
    [SerializeField] private Sprite[] flags;
    [SerializeField] private string[] names;

    [Header("Texts&Images")]
    [SerializeField] private Text namesText; 
    [SerializeField] private Image flagImage;
    [SerializeField] private Image meImg;
    
    void Start()
    {
        ChooseEnemy();
        i=PlayerPrefs.GetInt("numbFlag");
        meImg.sprite = flags[i];
    }

    void Update()
    {
        
    }

    void ChooseEnemy()
    {
        int rName = Random.Range(0,names.Length); //случайно имя противника
        int rFlag = Random.Range(0,flags.Length); //случайный флаг противника
        int p = playerController.maxPoints / 50; //диапозон очков противника
        //расчет очков противника
        if (playerController.maxPoints < 51)
        {
            enemyPoints = Random.Range(0,51);
        } 
        else if (p >= 1)
        {
            enemyPoints = Random.Range(p*50,p*50+51);
        }
        //назначение и показ заданных выше переменных игроку
        enPoints = enemyPoints;
        flagImage.sprite = flags[rFlag];
        namesText.text = names[rName] + "\n" + enemyPoints.ToString();
    }

    //функция отображения и сохранения флага игрока
    public void MeImg()
    {
        if (i < 26)
            i++;
        else    
            i = 0;
        meImg.sprite = flags[i];
        PlayerPrefs.SetInt("numbFlag", i);
    }
}
