using UnityEngine;

public class TitleButton : MonoBehaviour
{

    [SerializeField] private GameObject helpUi;
    // フェードの処理があるなら、それが終わったときにtrueにしてもらう
    private int spaceCount = 0;

    [SerializeField] CoinManager coinManager;
    [SerializeField] UseCoin useCoin;
    private void Start()
    {
        ScoreKeep.AllValueReset();
    }

    public void GetButton()
    {
        if (!HelpUICount.isFirstHelpShown)
        {
            HelpUICount.isFirstHelpShown = true;
            AudioManager.Instance.SelectSEPlay();
            spaceCount++;
            helpUi.SetActive(true);
        }
        else
        {
            if (spaceCount > 1) { return; }
            AudioManager.Instance.SelectSEPlay();
            coinManager.DecrementCoin();
            useCoin.CoinAnimStart();
            spaceCount++;
            TestParticle.Instance.fadeCall();
        }
    }
}
