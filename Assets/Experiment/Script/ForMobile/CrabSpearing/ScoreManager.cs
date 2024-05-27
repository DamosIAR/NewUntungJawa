using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public GameObject gameOverPanel;
    public float scoreToReach;
    public int score;
    public static ScoreManager instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        score = 0;
        gameOverPanel.SetActive(false);
        scoreText.text = "" + score;

    }

    public void updateScore()
    {
        Debug.Log("score bertambah");
        score += 1;
        scoreText.text = "" + score;

        /*if(score >= scoreToReach)
        {
            gameOverPanel.SetActive(true);

        }*/

    }

    public float getScore()
    {
        return score;
    }
}
