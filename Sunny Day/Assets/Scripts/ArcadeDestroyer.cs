using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcadeDestroyer : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("ground"))
        {
            Destroy(gameObject); //уничтожение объекта при столкновении с землей или игроком
        }
    }
}
