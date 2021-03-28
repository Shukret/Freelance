using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GoogleMobileAds.Api;

public class MobAdsSimple : MonoBehaviour
{
    private InterstitialAd interstitialAd;

#if UNITY_ANDROID
    private const string interstitialUnitId = "ca-app-pub-1874191787915042/8011786968"; //тестовый айди
#elif UNITY_IPHONE
    private const string interstitialUnitId = "";
#else
    private const string interstitialUnitId = "unexpected_platform";
#endif
    //билд рекламного блока
    void OnEnable()
    {
        interstitialAd = new InterstitialAd(interstitialUnitId);
        AdRequest adRequest = new AdRequest.Builder().Build();
        interstitialAd.LoadAd(adRequest);
    }

    //функция включения рекламного блока
    public void ShowAd()
    {
        if (interstitialAd.IsLoaded())
        {
            interstitialAd.Show();
        }
    }
}
