using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    //  public GameObject coinObject=null;

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
        coin += 3;

        coin = PlayerPrefs.GetInt("COIN", coin);
        PlayerPrefs.Save();

        coinText.text = "所持コイン\n" + coin.ToString();
    }
}
