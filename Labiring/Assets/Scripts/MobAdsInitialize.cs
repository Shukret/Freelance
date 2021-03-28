using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GoogleMobileAds.Api;

public class MobAdsInitialize : MonoBehaviour
{
    //инициализируем рекламу AdMob
    void Awake()
    {
        MobileAds.Initialize(initStatus => { });
    }
}
