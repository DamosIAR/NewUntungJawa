using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TimerText;
    [SerializeField] private Image TimerImage;
    [SerializeField] private Canvas gameOver;
    [SerializeField] private TextMeshProUGUI Score;

    private float timerTime;
    private float maxTime;

    private void Start()
    {
        SpearGameManager.Instance.StateChanged += SpearGameManager_onStateChanged;
        SpearGameManager.Instance.TimerChanged += SpearGameManager_TimerChanged;
        Hide();
    }

    private void SpearGameManager_TimerChanged(object sender, SpearGameManager.TimerChangedEventArgs e)
    {
        TimerImage.fillAmount = e.timeNormalised;
    }

    private void SpearGameManager_onStateChanged(object sender, System.EventArgs e)
    {
        if (SpearGameManager.Instance.isGameOver())
        {
            Show();
        }
        else
        {
            Hide();
        }


    }

    private void Hide()
    {
        gameOver.gameObject.SetActive(false);
    }

    private void Show()
    {
        Score.text = ("Final Score : ") + ScoreManager.instance.getScore().ToString();
        gameOver.gameObject.SetActive(true);
        ScoreManager.instance.getScore();
        ScoreManager.instance.highScore();
        //ScoreManager.instance.updateHighScore();
    }

    void Update()
    {
        maxTime = SpearGameManager.Instance.getGamePlayingTimerMax();
        if (!SpearGameManager.Instance.isGamePlaying()) return;
        if (timerTime < maxTime)
        {
            maxTime -= Time.deltaTime;
        }
        else if (timerTime >= maxTime)
        {
            Show();
            maxTime = timerTime;

        }

        int minutes = (int)maxTime / 60;
        int seconds = (int)maxTime % 60;
        TimerText.text = string.Format("{00:00} : {01:00}", minutes, seconds);
    }
}
