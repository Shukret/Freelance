using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class UnityAdsInitialize : MonoBehaviour
{
    //инициализация баннера UnityAd
    void Start()
    {
        Advertisement.Initialize("3994001", true);
    }
}