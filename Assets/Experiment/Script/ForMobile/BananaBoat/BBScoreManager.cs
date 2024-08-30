using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class BBScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ScoreText;
    [SerializeField] private TextMeshProUGUI HighScore;
    [SerializeField] private TextMeshProUGUI CurrentScore;

    private int score = 0;
    private float timeElapsed = 0;
    private float interval = 1f;

    public static BBScoreManager Instance { get; private set; }

    private void Start()
    {
        Instance = this;
        UpdateHighScore();
    }

    private void Update()
    {
        if(!BananaBoatGameManager.Instance.isPlaying()) return;
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= interval)
        {
            score += 10;
            ScoreText.text = score.ToString();
            timeElapsed = 0;
            highScore();
            UpdateHighScore();
        }
    }

    private void highScore()
    {
        if(score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }

    private void UpdateHighScore()
    {
        HighScore.text = "Skor Tertinggi : " + PlayerPrefs.GetInt("HighScore", 0);
        CurrentScore.text = "Skor Saat Ini : " + GetCurrentScore();
    }

    public int GetCurrentScore()
    {
        return score;
    }
}
