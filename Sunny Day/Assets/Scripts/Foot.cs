using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foot : MonoBehaviour
{
    [SerializeField] private PlayerController playerController; //скрипт игрока
    
    //проверка ног на соприкосновение с землей
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ground")
        {
            playerController.isGround = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "ground")
        {
            playerController.isGround = false;
        }
    }
}
