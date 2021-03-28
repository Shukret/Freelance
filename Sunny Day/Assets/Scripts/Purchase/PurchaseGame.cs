using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class PurchaseGame : MonoBehaviour
{
    [SerializeField] private TimeSystem ts; //переменная для времени подписки
    public static int ads = 0; //включена ли подписка?
    // Start is called before the first frame update
    void Start()
    {
        PurchaseManager.OnPurchaseConsumable += PurchaseManager_OnPurchaseConsumable;
    }

    void LateUpdate()
    {
        if(PurchaseManager.CheckBuyState("NoAds"))
        {
            ads = 1;
        }
    }


    public void PurchaseManager_OnPurchaseConsumable(PurchaseEventArgs args) //функция подключения подписки
    {
        ads = 1;
        ts.startDate = System.DateTime.Now;
        Debug.Log(ts.startDate);
        PlayerPrefs.SetString("LastSession", ts.startDate.ToString());
        Debug.Log("Your purchase: " + args.purchasedProduct.definition.id);
        Debug.Log("Ads:" + ads.ToString());
    }
}
