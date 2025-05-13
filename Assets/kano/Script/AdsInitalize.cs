using UnityEngine;
using UnityEngine.Advertisements;

public class AdsInitalize : MonoBehaviour
{
    [SerializeField] string _androidGameId = "YOUR_Android_GAME_ID";
    [SerializeField] string _iOSGameId = "YOUR_IOS_GAME_ID";
    [SerializeField] bool _testMode = true;
    [SerializeField] RewardedAdsButton[] rewardedAdsButton;
    [SerializeField] BannerManager bannerManager;

    string _gameId;

    private void Start()
    {
#if UNITY_IOS
        _gameId = _iOSGameId;
#elif UNITY_ANDROID
        _gameId = _androidGameId;
#endif

        if (Advertisement.isInitialized) 
        {
            foreach(var button in rewardedAdsButton)
            {
                Debug.Log("UnityAdsは初期化済みです");
                button.LoadAd();
            }
        }
        else
        {// IUnityAdsInitializationListener を実装したクラスを渡す
            Advertisement.Initialize(_gameId, _testMode, new AdsInitializationListener(this));
            bannerManager.LoadBanner();
        }
    }
    // 初期化を完了したときの処理
    private class AdsInitializationListener : IUnityAdsInitializationListener
    {
        private AdsInitalize _adsInitalize;

        public AdsInitializationListener(AdsInitalize adsInitalize)
        {
            _adsInitalize = adsInitalize;
        }

        public void OnInitializationComplete()
        {
            foreach (var button in _adsInitalize.rewardedAdsButton)
            {
                Debug.Log("Unity Ads 初期化完了！");
               button.LoadAd();  // 広告の読み込み開始
            }
        }

        // 失敗時に実行されるメソッド
        public void OnInitializationFailed(UnityAdsInitializationError error, string message)
        {
            Debug.LogError($"Unity Ads 初期化失敗: {error.ToString()} - {message}");
        }
    }
}
