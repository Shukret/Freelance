using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class UnityAdsBanner : MonoBehaviour
{
    public string placementId = "Banner";

    void Start()
    {
        if (PurchaseGame.ads == 0)
            StartCoroutine(ShowBannerWhenReady());
    }

    public IEnumerator ShowBannerWhenReady()
    {
        while (!Advertisement.IsReady(placementId))
        {
            yield return new WaitForSeconds(0.5f);
        }

        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        Advertisement.Banner.Show(placementId);
    }
    
    void Update()
    {
        if (PurchaseGame.ads == 1)
        {
            Advertisement.Banner.Hide();
        }
    }
}