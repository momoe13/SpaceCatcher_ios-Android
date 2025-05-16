using UnityEngine;
using UnityEngine.Advertisements;

public class BannerManager : MonoBehaviour
{

    [SerializeField] BannerPosition _bannerPosition = BannerPosition.CENTER;

    [SerializeField] string _androidAdUnitId = "Banner_Android";
    [SerializeField] string _iOSAdUnitId = "Banner_iOS";
    string _adUnitId = null; // This will remain null for unsupported platforms.

    void Start()
    {
        // 現在のプラットフォームの広告ユニット ID を取得します。
#if UNITY_IOS
        _adUnitId = _iOSAdUnitId;
#elif UNITY_ANDROID
        _adUnitId = _androidAdUnitId;
#endif


        // バナーの位置を設定します:
        Advertisement.Banner.SetPosition(_bannerPosition);

    }

    // Implement a method to call when the Load Banner button is clicked:
    public void LoadBanner()
    {
        // Load Banner ボタンがクリックされたときに呼び出すメソッドを実装します。
        BannerLoadOptions options = new BannerLoadOptions
        {
            loadCallback = OnBannerLoaded,
            errorCallback = OnBannerError
        };

        //バナーコンテンツを含む広告ユニットを読み込みます:
        Advertisement.Banner.Load(_adUnitId, options);
    }

    //loadCallback イベントがトリガーされたときに実行するコードを実装します。
    void OnBannerLoaded()
    {
        Debug.Log("Banner loaded");

    }

    // ロード errorCallback イベントがトリガーされたときに実行するコードを実装します。
    void OnBannerError(string message)
    {
        Debug.Log($"Banner Error: {message}");
        // オプションで、別の広告の読み込みなどの追加コードを実行します。
    }

    // バナーを表示ボタンがクリックされたときに呼び出すメソッドを実装します。
    public void ShowBannerAd()
    {
        // SDK にショーイベントを通知するためのオプションを設定します。
        BannerOptions options = new BannerOptions
        {
            clickCallback = OnBannerClicked,
            hideCallback = OnBannerHidden,
            showCallback = OnBannerShown
        };

        // 読み込まれたバナー広告ユニットを表示します。
        Advertisement.Banner.Show(_adUnitId, options);
    }

    //バナーを非表示ボタンがクリックされたときに呼び出すメソッドを実装します
    public void HideBannerAd()
    {
        // バナーを非表示にする
        Advertisement.Banner.Hide();
    }

    void OnBannerClicked() { }
    void OnBannerShown() { }
    void OnBannerHidden() { }

}
