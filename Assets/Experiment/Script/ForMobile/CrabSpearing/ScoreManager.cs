using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public float scoreToReach;
    public int score;
    public static ScoreManager instance;
    public TextMeshProUGUI highScoreText;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        score = 0;
        scoreText.text = "" + score;

    }

    public void updateNormalScore()
    {
        score += 2;
        scoreText.text = "" + score;
        //highScore();
    }

    public void updateSpecialScore()
    {
        score += 4;
        scoreText.text = "" + score;
        //highScore();
    }

    public int getScore()
    {
        return score;
    }

    public void highScore()
    {
        if(score > PlayerPrefs.GetInt("CrabHighScore", 0))
        {
            PlayerPrefs.SetInt("CrabHighScore", score);
        }
        updateHighScore();
    }

    public void updateHighScore()
    {
        highScoreText.text = "Skor Tertinggi : " + PlayerPrefs.GetInt("CrabHighScore", 0);
    }
}
