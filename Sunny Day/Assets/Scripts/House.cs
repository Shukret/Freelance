using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class House : MonoBehaviour
{
    [SerializeField] private string nextLevel; //переменная названия следующей сцены
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.gameObject.GetComponent<PlayerKeys>().keys >= 4)
            {
                SceneManager.LoadScene(nextLevel); //если игрок собрал все ключи и подошел к двери, то он переходит на следующий уровень
            }
        }
    }
}
