using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerKeys : MonoBehaviour
{
    [SerializeField] private Text keysText; //текст, отображающий количество ключей
    public int keys; //сколько ключей собрано

    void OnTriggerEnter2D(Collider2D other)
    {
        //прикосновение с ключом
        if(other.CompareTag("key"))
        {
            keys += 1; //прибавить собранные ключи
            Destroy(other.gameObject); //удалить ключ
        }
    }

    void Update()
    {
        keysText.text = "Keys: " + keys.ToString(); //текст показывает, сколько ключей мы собрали
    }
}
