using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class BBScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ScoreText;

    private int scoreStorage = 0;
    private float timeElapsed = 0;
    private float interval = 1f;

    private void Update()
    {
        if(!BananaBoatGameManager.Instance.isPlaying()) return;
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= interval)
        {
            scoreStorage += 10;
            ScoreText.text = scoreStorage.ToString();
            timeElapsed = 0;
        }
    }
}
