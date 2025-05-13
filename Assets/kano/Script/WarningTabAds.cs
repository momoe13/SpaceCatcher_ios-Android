using UnityEngine;

public class WarningTabAds : RewardedAdsButton
{//リワードボタンを継承
    [SerializeField]BannerManager bannerManager;
    //コイン３枚取得の処理を上書き
    public override void GiveItme()
    {
        //コイン１枚取得
        if (RewardFlg)
        {
            Debug.Log("報酬はすでに与えられました");
            return;
        }
        RewardFlg = true;
        if (coinManager != null)
        {
            coinManager.WarningTabCoin ();
            Debug.Log("コイン追加完了");
        }
        bannerManager.HideBannerAd();
    }
}
