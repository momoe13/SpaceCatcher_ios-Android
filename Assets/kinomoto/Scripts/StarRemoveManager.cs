using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarRemoveManager : MonoBehaviour
{
    private void Update()
    {
        //Kキーを押した際に星のタグが付いたオブジェクトをすべて削除する
        if (Input.GetKey(KeyCode.K))
        {
            AllRemoveStar();
        }
    }
    public void AllRemoveStar()
    {
        //指定したタグ（星）のオブジェクトを配列に入れる
        GameObject[] stars = GameObject.FindGameObjectsWithTag("Star");

        //配列に入れたオブジェクトを一つずつ繰り返し消している
        foreach (GameObject star in stars)
        {
            Destroy(star);
        }
    }
}
