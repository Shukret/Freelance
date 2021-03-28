using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class player : MonoBehaviour 
{
    static Plane plane;
    public static int points; //количество очков
    [SerializeField] private Text pointsText; //текст, отображающий очки
    //переменные координат границ экрана
    public Vector2 left_bottom;
	public Vector2 right_bottom;
	public Vector2 left_top;
	public Vector2 right_top;

    [SerializeField] private AudioSource eatSound; //звук поедания фруктовs
    void Start()
    {
        //вычисление всех границ камеры на старте
        plane = new Plane(transform.forward, transform.position);
        left_bottom = CalcPosition(new Vector2(0f, 0f));
        right_bottom = CalcPosition(new Vector2(Screen.width, 0f));
        left_top = CalcPosition(new Vector2(0f, Screen.height));
        right_top = CalcPosition(new Vector2(Screen.width, Screen.height));
    }

    void Update()
    {
        Vector3 mp = Camera.main.ScreenToWorldPoint(Input.mousePosition); //определение точки нажатия
        transform.position = new Vector3(mp.x,mp.y,gameObject.transform.position.z); //перемещение персонажа в эту точку
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //сталкивание с фруктом
        if(other.CompareTag("fruit"))
        {
            eatSound.Play(); //включить звук поедания
            points += 1; //прибавить очки
            pointsText.text = points.ToString(); //отобразить новое количество очков в тексте
            Destroy(other.gameObject); //уничтожить фруктs
        }
    }

    //функция определения границ экрана
    public Vector3 CalcPosition(Vector2 screenPos)
    {
        Ray ray = Camera.main.ScreenPointToRay(screenPos);
        float dist = 0f;
        Vector3 pos = Vector3.zero;

        if (plane.Raycast(ray, out dist))
            pos = ray.GetPoint(dist);

        return pos;
    }
}