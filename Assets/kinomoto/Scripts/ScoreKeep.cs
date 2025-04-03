
using UnityEditor;

public static class ScoreKeep
{
    public static int score;//基本スコア

    public static int sterScore;//スター取得数の変数

    public static int basePowerUpScore;//基礎パワーアップアイテム取得数の変数

    public static int ratePowerUpScore;//倍率パワーアップアイテム取得数の変数

    public static int widthPowerUpScore;//横幅パワーアップアイテム取得数の変数

    public static int turnRecoveryUpScore;//ターン回復アイテム取得数の変数

    public static int prizeScore;//景品アイテム獲得数の変数

    public static void AllValueReset()
    {
        score = 0;
        sterScore = 0;
        basePowerUpScore = 0;
        ratePowerUpScore = 0;
        widthPowerUpScore = 0;
        turnRecoveryUpScore = 0;
        prizeScore = 0;
    }
}
