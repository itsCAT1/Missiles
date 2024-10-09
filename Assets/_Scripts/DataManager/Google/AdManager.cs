using GoogleMobileAds.Api;
using UnityEngine;

public class AdManager : MonoBehaviour
{
    public string appID = "ca-app-pub-3673124410427702~9018088620";
    string adEndGameId = "ca-app-pub-3673124410427702/6045275079";
    string adBonusCoindID = "ca-app-pub-3673124410427702/9748780008";

    RewardedAd rewardedAd;
    InterstitialAd interstitialAd;

    void Start()
    {
        MobileAds.Initialize(initStatus => { });
    }
}