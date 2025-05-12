using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class RewardedAdsButton : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField]
    protected　CoinManager coinManager;

    [SerializeField] Button _showAdButton;
    string _androidAdUnitId = "Rewarded_Android";//Adunitsにある広告のIDを入れる
    string _iOSAdUnitId = "Rewarded_iOS";
    string _adUnitId = null; // 未対応プラットフォームでは null のまま
    //---------加納----
    protected bool RewardFlg = false;

    public string AdUnitId => _adUnitId;
    void Awake()
    {
        //現在のプラットフォームに応じた広告ユニットIDを取得
#if UNITY_IOS
        _adUnitId = _iOSAdUnitId;
#elif UNITY_ANDROID
        _adUnitId = _androidAdUnitId;
#endif

        // 一度だけリスナーを登録
        _showAdButton.onClick.AddListener(ShowAd);
        // 広告が準備できるまでボタンを無効化
        _showAdButton.interactable = false;
    }

    // 外部から呼び出して広告の読み込みを開始する
    public void LoadAd()
    {
        // 注意！ 初期化が完了してから読み込みを行うこと（この例では初期化は別スクリプトで行う）
        Debug.Log("広告を読み込み中: " + _adUnitId);
        Advertisement.Load(_adUnitId, (IUnityAdsLoadListener)this);
    }

    // 広告が正常に読み込まれたときの処理
    public void OnUnityAdsAdLoaded(string adUnitId)
    {
        Debug.Log("広告が読み込まれました: " + adUnitId);

        if (adUnitId.Equals(_adUnitId))
        {
            // ボタンを有効化してユーザーが押せるようにする
            _showAdButton.interactable = true;

            RewardFlg = false; // 新しい広告に備えて報酬フラグをリセット

        }
    }

    // ボタンが押されたときに実行される処理
    public void ShowAd()
    {
        // ボタンを一時的に無効化
        _showAdButton.interactable = false;
        // 広告を表示
        Advertisement.Show(_adUnitId, (IUnityAdsShowListener)this);
    }

    // 広告の視聴が完了したときの処理（ユーザーに報酬を与えるかどうかの判定）
    public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState)
    {

        if (adUnitId.Equals(_adUnitId) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            GiveItme();
            LoadAd();
        }
    }

    //-----加納 2025/05/12広告報酬の内容を書き換え使いまわせるように変更
    //デフォだとコイン３枚が付与される
    public virtual void GiveItme()
    {
        //---------加納
        if (RewardFlg)
        {
            Debug.Log("報酬はすでに与えられました");
            return;
        }
        RewardFlg = true;
        //---------加納
        if (coinManager != null)
        {
            coinManager.AdsCoin();
            Debug.Log("コイン追加完了");
        }
    }
   
    //-----加納
    //広告の読み込みに失敗したときの処理
    public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"広告ユニット {adUnitId}の読み込みエラー: {error.ToString()} - {message}");
        // エラーの内容に応じて別の広告を読み込むかどうかを判断する
    }

    public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message)
    {
        Debug.Log($"広告ユニット {adUnitId}の読み込みエラー: {error.ToString()} - {message}");
        // エラーの内容に応じて再読み込みなどの処理を検討する
    }

    // 広告の表示が開始されたときの処理（必要なら実装）
    public void OnUnityAdsShowStart(string adUnitId) { }

    // 広告がクリックされたときの処理（必要なら実装
    public void OnUnityAdsShowClick(string adUnitId) { }

    void OnDestroy()
    {
        // ボタンのリスナーを削除してメモリリークを防ぐ
        _showAdButton.onClick.RemoveAllListeners();
    }
}
