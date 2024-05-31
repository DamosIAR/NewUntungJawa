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

    }

    public float getScore()
    {
        return score;
    }
}
