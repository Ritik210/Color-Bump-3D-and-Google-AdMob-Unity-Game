using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using GoogleMobileAds.Api;

public class ADManager : MonoBehaviour
{
    private string APP_ID = "ca-app-pub-5801244947947812~1178721000";

    private BannerView bannerAD;
    private InterstitialAd InterstitialAd;
    private RewardBasedVideoAd rewardVideoAd;
    
    void Start()
    {
        RequestBanner();
        RequestInterstitial();
        RequestVideoAd();
    }

   void RequestBanner()
    {
        string banner_ID = "ca-app-pub-3940256099942544/6300978111";
        bannerAD = new BannerView(banner_ID, AdSize.SmartBanner, AdPosition.Top);

        AdRequest adRequest = new AdRequest.Builder().AddTestDevice("2077ef9a63d2b398840261c8221a0c9b").Build();

        bannerAD.LoadAd(adRequest);
    }

    void RequestInterstitial()
    {
        string Interstitial_ID = "ca-app-pub-3940256099942544/1033173712";
        InterstitialAd = new InterstitialAd(Interstitial_ID);

        AdRequest adRequest = new AdRequest.Builder().AddTestDevice("2077ef9a63d2b398840261c8221a0c9b").Build();

        InterstitialAd.LoadAd(adRequest);
    }
    void RequestVideoAd()
    {
        string Video_ID = "ca-app-pub-3940256099942544/5224354917";
        rewardVideoAd = RewardBasedVideoAd.Instance;

        AdRequest adRequest = new AdRequest.Builder().AddTestDevice("2077ef9a63d2b398840261c8221a0c9b").Build();

        rewardVideoAd.LoadAd(adRequest, Video_ID);
    }

    public void Display_Banner()
    {
        bannerAD.Show();
    }

    public void Display_InterstitislAD()
    {
        if(InterstitialAd.IsLoaded())
        {
            InterstitialAd.Show();
        }
    }

    public void Display_Reward_Video()
    {
        if(rewardVideoAd.IsLoaded())
        {
            rewardVideoAd.Show();
        }
    }

    //Handle Events

    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        Display_Banner();
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        RequestBanner();
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received");
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLeavingApplication event received");
    }

    void HandleBannerADEvents(bool Subscribe)
    {
       if(Subscribe)
        {
            // Called when an ad request has successfully loaded.
            bannerAD.OnAdLoaded += this.HandleOnAdLoaded;
            // Called when an ad request failed to load.
            bannerAD.OnAdFailedToLoad += this.HandleOnAdFailedToLoad;
            // Called when an ad is clicked.
            bannerAD.OnAdOpening += this.HandleOnAdOpened;
            // Called when the user returned from the app after an ad click.
            bannerAD.OnAdClosed += this.HandleOnAdClosed;
            // Called when the ad click caused the user to leave the application.
            bannerAD.OnAdLeavingApplication += this.HandleOnAdLeavingApplication;
        }
       else
        {
            // Called when an ad request has successfully loaded.
            bannerAD.OnAdLoaded -= this.HandleOnAdLoaded;
            // Called when an ad request failed to load.
            bannerAD.OnAdFailedToLoad -= this.HandleOnAdFailedToLoad;
            // Called when an ad is clicked.
            bannerAD.OnAdOpening -= this.HandleOnAdOpened;
            // Called when the user returned from the app after an ad click.
            bannerAD.OnAdClosed -= this.HandleOnAdClosed;
            // Called when the ad click caused the user to leave the application.
            bannerAD.OnAdLeavingApplication -= this.HandleOnAdLeavingApplication;
        }
       void OnEnable()
        {
            HandleBannerADEvents(true);

        }
        void OnDisable()
        {
            HandleBannerADEvents(false);
        }

    }

}
