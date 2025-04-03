using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TestItemGetManager : MonoBehaviour
{
    [SerializeField] private GameObject cranePowerErea;
    [SerializeField] private GameObject targetManager;
    [SerializeField] private GameObject turnManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //スターを入れた時の処理
        if (collision.gameObject.tag == "Star")
        {
            Destroy(collision.gameObject);//オブジェクトを削除
            ScoreKeep.score += 10;//スコアを10点加算
            ScoreKeep.sterScore += 1;
        }
        //基礎パワーアップアイテムを入れたときの処理
        if (collision.gameObject.tag == "BasePowerUp")
        {
            cranePowerErea.GetComponent<MagneticForceVariable>().AddBase();//クレーンの基礎パワーを増加
            Destroy(collision.gameObject);//オブジェクトを削除
            ScoreKeep.score += 100;//スコアを100点加算
            ScoreKeep.basePowerUpScore += 1;
            Debug.Log("基礎値パワーアップ！");
        }
        //倍率パワーアップを入れたときの処理
        if (collision.gameObject.tag == "RatePowerUp")
        {
            cranePowerErea.GetComponent<MagneticForceVariable>().AddMagnification();//クレーンの倍率パワーを増加
            Destroy(collision.gameObject);//オブジェクトを削除
            ScoreKeep.score += 100;//スコアを100点加算
            ScoreKeep.ratePowerUpScore += 1;
            Debug.Log("倍率パワーアップ！");
        }
        //横幅パワーアップを入れたときの処理
        if(collision.gameObject.tag == "WidthPowerUp")
        {
            //クレーンのビーム部分の横幅を増加
            cranePowerErea.GetComponent<MagneticForceVariable>().ColliderSizeUp();
            Destroy(collision.gameObject);//オブジェクトを削除
            ScoreKeep.score += 100;//スコアを100点加算
            ScoreKeep.widthPowerUpScore += 1;
            Debug.Log("横幅パワーアップ！");
        }
        //ターン数+1を入れたときの処理
        if (collision.gameObject.tag == "TurnRecoveryUp")
        {
            turnManager.GetComponent<TurnManager>().TurnCountUp();//ターン+1
            Destroy(collision.gameObject);//オブジェクトを削除
            ScoreKeep.score += 100;//スコアを100点加算
            ScoreKeep.turnRecoveryUpScore += 1;
            Debug.Log("ターン数+1！");
        }
        //目標アイテムを取得した際の処理
        if (collision.gameObject.tag == "Target")
        {
            Destroy(collision.gameObject);//オブジェクトを削除
            ScoreKeep.score += 1000;//スコアを1000点加算
            ScoreKeep.prizeScore += 1;
            if (targetManager.GetComponent<TargetManager>().TargetNumber == int.Parse(collision.gameObject.name))
            {
                Debug.Log("目標のアイテムをゲット！");
            }
            else
            {
                Debug.Log("ターゲットアイテムをゲット！");
            }
        }
    }
}
