using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class menu : MonoBehaviour
{
    [SerializeField] private bool open;
    [SerializeField] private GameObject panelRes;
    [SerializeField] private Text[] resText;
    static bool res = false;
    void Start()
    {
        if (!res)
        {
            //создание массива с лучшими результатами и обнуление его в первый раз
            results.best = new int[3];
            for(int i=0; i<results.best.Length;i++)
                results.best[i] = 0;
            res = true;
        }
    }
    //функция кнопки старта
    public void StartBtn()
    {
        SceneManager.LoadScene("Game");
    }
    
    //функция кнопки лучших результатов
    public void BestResult()
    {
        //открытие панели
        if (open)
        {
            panelRes.SetActive(true);
            open = false;
        }
        //закрытие панели
        else if(!open)
        {
            panelRes.SetActive(false);
            open = true;
        }
        // показ результатов текстами
        resText[0].text = "1. " + results.best[0].ToString(); 
        resText[1].text = "2. " + results.best[1].ToString(); 
        resText[2].text = "3. " + results.best[2].ToString(); 
    }
}