using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class BannerManager : MonoBehaviour
{
    // For the purpose of this example, these buttons are for functionality testing:
   //[SerializeField] Button _loadBannerButton;
   // [SerializeField] Button _showBannerButton;
   // [SerializeField] Button _hideBannerButton;

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

        // 広告の表示準備ができるまでボタンを無効にします。
        //_showBannerButton.interactable = false;
        //_hideBannerButton.interactable = false;

        // バナーの位置を設定します:
        Advertisement.Banner.SetPosition(_bannerPosition);

        // クリックすると LoadBanner() メソッドが呼び出されるように Load Banner ボタンを構成します。
       // _loadBannerButton.onClick.AddListener(LoadBanner);
      //  _loadBannerButton.interactable = true;
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

        //クリックすると ShowBannerAd() メソッドが呼び出されるように [バナーを表示] ボタンを構成します。
       //_showBannerButton.onClick.AddListener(ShowBannerAd);
       //// バナーを非表示ボタンを構成して、クリックすると HideBannerAd() メソッドが呼び出されます。
       //_hideBannerButton.onClick.AddListener(HideBannerAd);
       //
       //// 両方のボタンを有効にします:
       //_showBannerButton.interactable = true;
       //_hideBannerButton.interactable = true;
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
    void HideBannerAd()
    {
        // バナーを非表示にする
        Advertisement.Banner.Hide();
    }

    void OnBannerClicked() { }
    void OnBannerShown() { }
    void OnBannerHidden() { }

    void OnDestroy()
    {
        // リスナーをクリーンアップします:
       // _loadBannerButton.onClick.RemoveAllListeners();
      // _showBannerButton.onClick.RemoveAllListeners();
      // _hideBannerButton.onClick.RemoveAllListeners();
    }
}
