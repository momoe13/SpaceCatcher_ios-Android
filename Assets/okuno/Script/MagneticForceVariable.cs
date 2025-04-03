using UnityEngine;

public class MagneticForceVariable : MonoBehaviour
{
    [Header("連打処理の許可")]
    // スペースを押すとカウントを増やす処理をしてもいいかどうか
    public bool isSpace;
    [Header("連打回数")]
    [SerializeField] private int pushCount = 0;

    [Header("つかみ力倍率")]
    // 初期値
    [SerializeField] private float initialMagnification;
    // 現在の倍率
    [SerializeField] private float magnificationValue;
    // 加算する倍率値
    [SerializeField] private float addMagnificationValue = 0.01f;

    [Header("基礎値")]
    // 初期値
    [SerializeField] private float initialBase;
    // 現在の基礎値
    [SerializeField] private float baseValue;
    // 加算する基礎値
    [SerializeField] private float addBaseValue = -3f;

    [Header("最終値")]
    // 反映させるときの最終値
    [SerializeField] private float resultValue;

    // 範囲拡大時の値
    [SerializeField] private Vector2[] upPointAry;
    // 磁力範囲の初期値
    [SerializeField] private Vector2[] initialPointAry;

    void Start()
    {
        // 初期化
        AllValueReset();
    }

    //void Update()
    //{
    //    // isSpaceがtrueの間のみ、連打回数加算を許可する
    //    if (isSpace)
    //    {
    //        // スペースを押したらカウントを加算
    //        if (Input.GetKeyDown(KeyCode.Space))
    //        {
    //            pushCount++;
    //            Reflection();
    //        }
    //        /*-----------------テスト用コマンド-----------------*/
    //        // 磁力範囲拡大
    //        if (Input.GetKeyDown(KeyCode.U))
    //        {
    //            ColliderSizeUp();
    //        }
    //        // 磁力範囲縮小
    //        if (Input.GetKeyDown(KeyCode.R))
    //        {
    //            ColliderSizeReset();
    //        }
    //    }        
    //}

    public void GetKey()
    {
        // スペースを押したらカウントを加算
        pushCount++;
        Reflection();
    }
    /// <summary>
    /// 磁力の効果範囲の拡大
    /// </summary>
    public void ColliderSizeUp()
    {
        gameObject.GetComponent<PolygonCollider2D>().SetPath(0,upPointAry);
    }

    /// <summary>
    /// 磁力の効果範囲の縮小
    /// </summary>
    public void ColliderSizeReset()
    {
        gameObject.GetComponent<PolygonCollider2D>().SetPath(0,initialPointAry);
    }

    /// <summary>
    /// クレーンの磁力を完全にオフにする（オンにする場合Reflection()を呼び出す）
    /// </summary>
    public void MagneticOff()
    {
        gameObject.GetComponent<PointEffector2D>().forceMagnitude = 0;
    }

    /// <summary>
    /// クレーンの磁力関係の値を初期化
    /// </summary>
    public void AllValueReset()
    {
        magnificationValue = initialMagnification;
        baseValue = initialBase;
        pushCount = 0;
        // クレーンに反映
        Reflection();
    }

    /// <summary>
    /// クレーンに磁力の値を反映させるメソッド(磁力を戻したい場合もこれを呼び出す）
    /// </summary>
    public void Reflection()
    {
        // 最終値の計算
        resultValue = baseValue + ((magnificationValue * pushCount) * baseValue);
        // 計算された磁力をクレーンに反映させる
        gameObject.GetComponent<PointEffector2D>().forceMagnitude = resultValue;
    }

    /// <summary>
    /// 連打回数のみリセット
    /// </summary>
    public void ResetPushCount()
    {
        pushCount = 0;
    }

    /// <summary>
    /// つかみ力倍率を加算する（パワーアップアイテム獲得時に呼び出される）
    /// </summary>
    public void AddMagnification()
    {
        magnificationValue += addMagnificationValue;
        // クレーンに反映
        Reflection();
    }


    /// <summary>
    /// 基礎値を加算する（パワーアップアイテム獲得時に呼び出される）
    /// </summary>
    public void AddBase()
    {
        baseValue += addBaseValue;
        // クレーンに反映
        Reflection();
    }
}
