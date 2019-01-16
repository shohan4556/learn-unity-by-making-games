﻿using System;
using GoogleMobileAds.Api;
using UnityEngine;

public class MyAdManager : MonoBehaviour {
	public static MyAdManager Instance;

	[Header("App ID")] 
	public string appId;
	
	[Header("Banner ID")]
	public string BannerId;
	
	[Header("Interstitial ID")]
	public string InterstitialId;

	private InterstitialAd interstitial;
	private AdRequest requestBanner;
	private AdRequest requestInterstial;
	private BannerView bannerViewVar;

	
	private void Awake(){
		if (Instance != null) {
			Destroy(this);
		}
		else {
			Instance = this;
			DontDestroyOnLoad(this);
		}
	}

	// Use this for initialization
	private void Start(){
		// Initialize the Google Mobile Ads SDK.
		MobileAds.Initialize(appId);
		
		InitAds();
	}

	public void InitAds(){
		
		// Create a 320x50 banner at the top of the screen.
		//bannerViewVar = new BannerView(BannerId, AdSize.SmartBanner, AdPosition.Bottom);
		//requestBanner = new AdRequest.Builder().Build();
		//bannerViewVar.LoadAd(requestBanner);
		
		// Initialize an InterstitialAd.
		this.interstitial = new InterstitialAd(InterstitialId);
		
		this.interstitial.OnAdClosed += HandleOnAdClosed;
		
		// Create an empty ad request.
		AdRequest request = new AdRequest.Builder().Build();
		// Load the interstitial with the request.
		this.interstitial.LoadAd(request);
	}

	private void HandleOnAdClosed(object sender, EventArgs e){
		this.interstitial = new InterstitialAd(InterstitialId);
		AdRequest request = new AdRequest.Builder().Build();
		this.interstitial.LoadAd(request);
	}


	public void ShowInterstitial(){
		if (!this.interstitial.IsLoaded()) {
			this.interstitial = new InterstitialAd(InterstitialId);
			AdRequest request = new AdRequest.Builder().Build();
			this.interstitial.LoadAd(request);
		}
		
		this.interstitial.Show();
		
	}
	
	public void HideInterstital(){
		interstitial.Destroy();
	}

	public void ShowBanner(){
		// Load a banner ad.
		bannerViewVar = new BannerView(BannerId, AdSize.SmartBanner, AdPosition.Bottom);
		requestBanner = new AdRequest.Builder().Build();
		bannerViewVar.LoadAd(requestBanner);
		bannerViewVar.Show();
	
	}

	public void HideBanner(){ 
		//Debug.LogWarning("--------------------------------------> remove ads");
		if (bannerViewVar != null) {
			//bannerViewVar.Hide();
			bannerViewVar.Destroy();
		}
		
	}

	public void DestroyBanner(){
		if (bannerViewVar != null) {
			bannerViewVar.Destroy();
		}
	}

	public void ShowTopBanner(){
		bannerViewVar = new BannerView(BannerId, AdSize.MediumRectangle, AdPosition.Top);
		requestBanner = new AdRequest.Builder().Build();
		bannerViewVar.LoadAd(requestBanner);
		bannerViewVar.Show();
	}

	
}
