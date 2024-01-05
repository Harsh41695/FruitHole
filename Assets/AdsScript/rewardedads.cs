using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class rewardedads : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
   // [SerializeField] Button _showAdButton;
    [SerializeField] string _androidAdUnitId = "Rewarded_Android";
    [SerializeField] string _iOsAdUnitId = "Rewarded_iOS";
    string _adUnitId = null; // This will remain null for unsupported platforms
    //public int REWARDTIMES = 0;
    int typeOfCaller = -1;
    
    void Awake()
    {
        // Get the Ad Unit ID for the current platform:
        _adUnitId = (Application.platform == RuntimePlatform.IPhonePlayer)
          ? _iOsAdUnitId
          : _androidAdUnitId;

    }
    private void Start()
    {
#if UNITY_IOS
        _adUnitId = _iOsAdUnitId;
#elif UNITY_ANDROID
        _adUnitId = _androidAdUnitId;
#endif

        // Disable the button until the ad is ready to show:
        //_showAdButton.interactable = false;
        LoadAd();
        
    }
    // Call this public method when you want to get an ad ready to show.
    public void LoadAd()
    {
        // IMPORTANT! Only load content AFTER initialization (in this example, initialization is handled in a different script).
        Debug.Log("Loading Ad: " + _adUnitId);
        Advertisement.Load(_adUnitId, this);
    }

    // If the ad successfully loads, add a listener to the button and enable it:
    public void OnUnityAdsAdLoaded(string adUnitId)
    {
        Debug.Log("Ad Loaded: " + adUnitId);

        if (adUnitId.Equals(_adUnitId))
        {
            // Configure the button to call the ShowAd() method when clicked:
           // _showAdButton.onClick.AddListener(ShowAd);
            // Enable the button for users to click:
           // _showAdButton.interactable = true;
        }
    }
    public void MyShowAd(int typeOfCaller)
    {
        this.typeOfCaller = typeOfCaller;
        LoadAd();
        ShowAd();
    }
    // Implement a method to execute when the user clicks the button:
    public void ShowAd()
    {
        Advertisement.Show(_adUnitId, this);
    }

    // Implement the Show Listener's OnUnityAdsShowComplete callback method to determine if the user gets a reward:
    [System.Obsolete]
    public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState)
    {
        if (adUnitId.Equals(_adUnitId) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            Debug.Log("Unity Ads Rewarded Ad Completed");
           
            switch (typeOfCaller)
            {
                case 0:
                    HY_HoleBehaviour.instance.IncreaseSizeFromReward();
                    break;
                case 1:
                    HY_HoleBehaviour.instance.IncreacePowerLevel(1);
                    break;
                case 2:
                    HY_UIManager.instance.seconds += 5;
                    break;
                case 3:
                    HY_CoinMulitiplier.instance.CoinMultipier();
                    break;
                case 4:
                    GameManager.instance.diamonds += 2;
                    break;

            }
            typeOfCaller = -1;
            // Grant a reward.
        }
    }

    // Implement Load and Show Listener error callbacks:
    public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error loading Ad Unit {adUnitId}: {error.ToString()} - {message}");
        // Use the error details to determine whether to try to load another ad.
        //_showAdButton.interactable=false;
    }

    public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message)
    {
        typeOfCaller = -1;

        Debug.Log($"Error showing Ad Unit {adUnitId}: {error.ToString()} - {message}");
        
    }

    public void OnUnityAdsShowStart(string adUnitId) { }
    public void OnUnityAdsShowClick(string adUnitId) { }

}