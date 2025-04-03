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
        //�������A�n�C�X�R�A���p��
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

        //�e�L�X�g�̕\������
        scoreText.text = ScoreKeep.score.ToString() + "�Ă�";
        sterScoreText.text = "�~:" + ScoreKeep.sterScore.ToString();
        basePowerUpScoreText.text = "�~" + ScoreKeep.basePowerUpScore.ToString();
        ratePowerUpScoreText.text = "�~" + ScoreKeep.ratePowerUpScore.ToString();
        widthPowerUpScoreText.text = "�~" + ScoreKeep.widthPowerUpScore.ToString();
        turnRecoveryUpScoreText.text = "�~" + ScoreKeep.turnRecoveryUpScore.ToString();

        highScoreText.text = "�n�C�X�R�A:" + highScore.ToString();

        //�n�C�X�R�A�̏���
        if (ScoreKeep.score >= highScore)
        {
            highScore = ScoreKeep.score;

            PlayerPrefs.SetInt("HIGHSCORE",highScore);
            PlayerPrefs.Save();
        }
    }
}
