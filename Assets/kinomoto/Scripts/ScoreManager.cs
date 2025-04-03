using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public GameObject scoreObject = null;
    public GameObject sterScoreObject = null;
    public GameObject basePowerUpScoreObject = null;
    public GameObject ratePowerUpScoreObject = null;
    public GameObject widthPowerUpScoreObject = null;
    public GameObject turnRecoveryUpScoreObject = null;
    //public GameObject prizeScoreObject = null;

    public GameObject highScoreObject = null;

    public int highScore = 0;

    private void Start()
    {
        //初期化、ハイスコア引継ぎ
        highScore = PlayerPrefs.GetInt("HIGHSCORE", 0);
    }
    private void Update()
    {
        Text scoreText = scoreObject.GetComponent<Text>();
        Text sterScoreText = sterScoreObject.GetComponent<Text>();
        Text basePowerUpScoreText = basePowerUpScoreObject.GetComponent<Text>();
        Text ratePowerUpScoreText = ratePowerUpScoreObject.GetComponent<Text>();
        Text widthPowerUpScoreText = widthPowerUpScoreObject.GetComponent<Text>();
        Text turnRecoveryUpScoreText = turnRecoveryUpScoreObject.GetComponent<Text>();
        //Text prizeScoreText = prizeScoreObject.GetComponent<Text>();

        Text highScoreText = highScoreObject.GetComponent<Text>();

        //テキストの表示入替
        scoreText.text = ScoreKeep.score.ToString() + "てん";
        sterScoreText.text = "×:" + ScoreKeep.sterScore.ToString();
        basePowerUpScoreText.text = "×" + ScoreKeep.basePowerUpScore.ToString();
        ratePowerUpScoreText.text = "×" + ScoreKeep.ratePowerUpScore.ToString();
        widthPowerUpScoreText.text = "×" + ScoreKeep.widthPowerUpScore.ToString();
        turnRecoveryUpScoreText.text = "×" + ScoreKeep.turnRecoveryUpScore.ToString();

        highScoreText.text = "ハイスコア:" + highScore.ToString();

        //ハイスコアの処理
        if (ScoreKeep.score >= highScore)
        {
            highScore = ScoreKeep.score;

            PlayerPrefs.SetInt("HIGHSCORE",highScore);
            PlayerPrefs.Save();
        }
    }
}
