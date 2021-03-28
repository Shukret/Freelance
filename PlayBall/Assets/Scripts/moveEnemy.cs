using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveEnemy : MonoBehaviour
{
    [SerializeField] private float speed; //скорость движения врагов
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(-speed*Time.deltaTime,0,0); //постоянное движение влево
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //столкновение с другими врагами, выходом за экран, ромбами
        if (other.CompareTag("enemy") || other.CompareTag("death") || other.CompareTag("green") || other.CompareTag("red") || other.CompareTag("blue"))
        {
            Destroy(gameObject); //уничтожить объект
        }
    }
}
