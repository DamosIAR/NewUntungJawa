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

    public void updateScore()
    {
        score += 1;
        scoreText.text = "" + score;
        //highScore();
    }

    public float getScore()
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
        highScoreText.text = "High Score : " + PlayerPrefs.GetInt("CrabHighScore", 0);
    }
}
