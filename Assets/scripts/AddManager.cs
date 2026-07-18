using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using GoogleMobileAds.Api;
using System;
public class AddManager : MonoBehaviour
{
    public static AddManager Instance;
    public GameObject checkInternet;
    private InterstitialAd interstitialAd;
    public UI ui;
    //private BannerView bannerView;
    private RewardedAd rewardedAd;
    private Action rewardAction;
    private static int RetryCount = 0;
    private string interstitialId =
        "ca-app-pub-9565881819222312/2153951234";

    //private string bannerId =
    //    "ca-app-pub-9565881819222312/5134316292";

    private string rewardedId =
        "ca-app-pub-9565881819222312/1811858817";
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        MobileAds.Initialize(initStatus =>
        {
            LoadInterstitial();
            LoadRewardedAd();
        });
    }
    //public void LoadBanner()
    //{
    //    if (bannerView != null)
    //    {
    //        bannerView.Destroy();
    //    }
    //    bannerView = new BannerView(
    //        bannerId,
    //        AdSize.Banner,
    //        AdPosition.Top);
    //    AdRequest request = new AdRequest();
    //    bannerView.LoadAd(request);
    //}
    //public void ShowBanner()
    //{
    //    if (bannerView == null)
    //    {
    //        LoadBanner();
    //        return;
    //    }
    //    bannerView.Show();
    //}
    //public void HideBanner()
    //{
    //    if (bannerView != null)
    //    {
    //        bannerView.Destroy();
    //        bannerView = null;
    //    }
    //}
    void LoadInterstitial()
    {
        if (interstitialAd != null)
        {
            interstitialAd.Destroy();
            interstitialAd = null;
        }
        AdRequest request = new AdRequest();
        InterstitialAd.Load(interstitialId, request,
            (InterstitialAd ad, LoadAdError error) =>
            {
                if (error != null || ad == null)
                {
                    Debug.Log("Interstitial failed to load.");
                    return;
                }
                interstitialAd = ad;
                interstitialAd.OnAdFullScreenContentClosed += () =>
                {
                    LoadInterstitial();
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                };
            });
    }
    public void ShowRetryAd()
    {
        RetryCount++;
        if (RetryCount % 2 == 0 && interstitialAd != null &&
            interstitialAd.CanShowAd())
        {
            interstitialAd.Show();
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    void LoadRewardedAd()
    {
        if (rewardedAd != null)
        {
            rewardedAd.Destroy();
            rewardedAd = null;
        }
        AdRequest request = new AdRequest();
        RewardedAd.Load(rewardedId, request,
            (RewardedAd ad, LoadAdError error) =>
            {
                if (error != null || ad == null)
                {
                    Debug.Log("Rewarded Ad failed to load.");
                    return;
                }
                rewardedAd = ad;
                rewardedAd.OnAdFullScreenContentClosed += () =>
                {
                    LoadRewardedAd();
                };
            });
    }
    public void ShowRewardedAd()
    {

        if (rewardedAd != null &&
            rewardedAd.CanShowAd())

        {
            ui.RevivePlayer();
            rewardedAd.Show((Reward reward) =>
            {
                Debug.Log("Reward Earned!");
                FindAnyObjectByType<UI>().GameOver.SetActive(false);
            });
        }
        else
        {
            StartCoroutine(CheckInternet());
            Debug.Log("Rewarded Ad not ready.");
            

            
        }
    }
    IEnumerator CheckInternet()
    {
        checkInternet.SetActive(true);
        yield return new WaitForSeconds(1);
        checkInternet.SetActive(false);
    }
}
