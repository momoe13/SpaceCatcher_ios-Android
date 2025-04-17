using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public GameObject coinObject=null;

    public int coin = 0;

    private void Start()
    {
        //‰Šú‰»AƒRƒCƒ“ˆøŒp‚¬
        coin = PlayerPrefs.GetInt("COIN", 0);
    }

    public void AdsCoin()
    {
        coin += 3;

        coin = PlayerPrefs.GetInt("COIN", coin);
        PlayerPrefs.Save();
    }
}
