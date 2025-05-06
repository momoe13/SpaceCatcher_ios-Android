using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScore : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Text highScoreText;

    private void Start()
    {
        scoreText.text = $"{ScoreKeep.score.ToString()}";
        highScoreText.text = $"{PlayerPrefs.GetInt("HIGHSCORE", 0)}";
    }
}
