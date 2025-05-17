using UnityEngine;

public class TitleButton : MonoBehaviour
{

    [SerializeField] private GameObject helpUi;
    // フェードの処理があるなら、それが終わったときにtrueにしてもらう
    private int spaceCount = 0;
    [SerializeField] CoinManager coinManager;
    [SerializeField] UseCoin useCoin;
    [SerializeField] GameObject ErrorPanel;
    [SerializeField] BannerManager bannerManager;

    //コイン枚数が１枚以上あるか確認する用
    bool coinFlg;
    private void Start()
    {
        ScoreKeep.AllValueReset();
        ErrorPanel.SetActive(false);
    }

    public void GetButton()
    {
        if (IsPlaying.isPlay)
        {
            if (!HelpUICount.isFirstHelpShown)
            {
                HelpUICount.isFirstHelpShown = true;
                AudioManager.Instance.SelectSEPlay();
                spaceCount++;
                helpUi.SetActive(true);
                int helpIndex = helpUi.transform.GetSiblingIndex();
                transform.SetSiblingIndex(helpIndex + 1);
            }
            else
            {
                if (spaceCount > 1) { return; }
                AudioManager.Instance.SelectSEPlay();
                coinFlg = coinManager.DecrementCoin();
                if (!coinFlg)
                { //広告を挟む。広告終了後ゲーム開始
                    bannerManager.ShowBannerAd();
                    ErrorPanel.SetActive(true);
                    return;
                }
                useCoin.CoinAnimStart();
                spaceCount++;
                TestParticle.Instance.fadeCall();
            }
        }
    }
}
