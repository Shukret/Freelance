using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GoogleMobileAds.Api;

public class MobAdsInitialize : MonoBehaviour
{
    //инициализация рекламы AdMob
    void Awake()
    {
        MobileAds.Initialize(initStatus => { });
    }
}
