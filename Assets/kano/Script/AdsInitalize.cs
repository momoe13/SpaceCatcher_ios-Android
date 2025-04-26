using UnityEngine;
using UnityEngine.Advertisements;
using System.Collections;

public class AdsInitalize : MonoBehaviour
{

    [SerializeField] string _androidGameId = "YOUR_ANDROID_GAME_ID";
    [SerializeField] string _iOSGameId = "YOUR_IOS_GAME_ID";
    [SerializeField] bool _testMode = true;
    [SerializeField] RewardedAdsButton rewardedAdsButton;

    string _gameId;

    void Awake()
    {
#if UNITY_IOS
        _gameId = _iOSGameId;
#elif UNITY_ANDROID
        _gameId = _androidGameId;
#endif

        Advertisement.Initialize(_gameId, _testMode);

        StartCoroutine(WaitForInitialize());
    }

    IEnumerator WaitForInitialize()
    {
        while (!Advertisement.isInitialized)
        {
            yield return null; // ñàÉtÉåÅ[ÉÄë“Ç¬
        }

        Debug.Log("Unity Ads èâä˙âªäÆóπÅI");
        rewardedAdsButton.LoadAd();
    }
}
