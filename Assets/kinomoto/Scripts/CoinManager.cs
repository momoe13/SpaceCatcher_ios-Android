using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    //public GameObject coinObject=null;

    [SerializeField]
    Text coinText;

    public int coin = 0;

    private void Start()
    {
        //初期化、コイン引継ぎ
        coin = PlayerPrefs.GetInt("COIN", 0);
        coinText.text = "所持コイン\n" + coin.ToString();
    }

    public void AdsCoin()
    {
        Debug.Log("AdsCoin() 実行された");
        coin += 3;
        SaveCoin();

    }

    //-----加納　複数回行う処理なのでまとめました
    private void SaveCoin()
    {
        //コイン枚数を保存
        PlayerPrefs.SetInt("COIN", coin);
        PlayerPrefs.Save();

        coinText.text = "所持コイン\n" + coin.ToString();
    }
    
    //コイン使用。コインが０枚以下の場合Falseを返す
    public bool DecrementCoin()
    {
        if (coin <= 0) { return false; }
        coin--;
        SaveCoin();
        return true;
    }

    public void WarningTabCoin()
    {
        coin += 1;
        SaveCoin();
    }

}
