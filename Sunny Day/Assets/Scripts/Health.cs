using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] private AudioSource hitFX; //переменная для звука удара
    [SerializeField] private int hp; //количество hp
    [SerializeField] private string thisScene; //название нынешней сцены
    bool canDamage; //может ли игрок получать дамаг

    [SerializeField] private GameObject[] imgHP; //массив UI-изображений жизней
    // Start is called before the first frame update
    void Start()
    {
        canDamage = true; //игрок может получать дамаг
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            SceneManager.LoadScene(thisScene); //рестарт сцены при поражении
        }

        //показ количества сердечек=количеству жизней
        for (int i = 0; i<imgHP.Length;i++)
        {
            if (hp>=i)
                imgHP[i-1].SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //столкновение с врагом
        if (other.CompareTag("enemy") && canDamage)
        {
            hp -= 1; //минус жизнь
            hitFX.Play(); //проиграть звук получения дамага
            StartCoroutine(NotDamage()); //стать неуязвимым на некоторое время
        }

        //столкновение со смертельной зоной
        if (other.CompareTag("zone"))
        {
            hp = 0;
        }
    }

    //корутина неуязвимости
    IEnumerator NotDamage()
    {
        canDamage = false;
        yield return new WaitForSeconds(0.5f);
        canDamage = true;
    }
}
