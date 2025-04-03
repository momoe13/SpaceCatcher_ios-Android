using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    [SerializeField] 
    public List<GameObject> targetSelect;//クリア目標のアイテムのリスト
    public int TargetNumber;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))//Cを押して目標を指定（仮）
        {
            TargetRandomSelect();
        }
    }

    public void TargetRandomSelect()
    {
        //リストの中からランダムに一つが選ばれる
        TargetNumber = Random.Range(0, targetSelect.Count);
        Debug.Log("目標のアイテムは" + targetSelect[TargetNumber]);
    }
}
