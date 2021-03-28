using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject[] platform;
    public Transform generationPoint;
    public float distanceBetween;

    public float platformWidth;
    int i = 0;

    int count;

    GameObject[] platformsArray;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        i = 0;
        StartCoroutine(spawn());
        platformsArray = new GameObject[2000];
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < platformsArray.Length; i++)
        {
            if (platformsArray[i])
            {
                platformsArray[i].transform.Translate(Vector3.left*1*Time.deltaTime);
                if (platformsArray[i].transform.position.x < 20)
                {
                    platformsArray[i].SetActive(true);
                }
                if (platformsArray[i].transform.position.x < -11)
                {
                    Destroy(platformsArray[i]);
                }
            }
        }
    }

    IEnumerator spawn()
    {
        if (i<2000)
        {
            yield return null;
            count+=1;
            int r = Random.Range(0, platform.Length);
            if (count < 8)
            {
                while (r == 0)
                {
                    r = Random.Range(0, platform.Length);
                }
            }
            transform.position = new Vector3(transform.position.x + platformWidth + distanceBetween, transform.position.y, transform.position.z);
            GameObject pl = Instantiate(platform[r], transform.position, transform.rotation);
            platformsArray[i] = pl;
            if (i>r)
                platformsArray[i].SetActive(false);
            i++;
            StartCoroutine(spawn());
        }
    }
}
