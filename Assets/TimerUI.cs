using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TimerText;
    [SerializeField] private Canvas gameOver;

    private float timerTime;
    private float maxTime;

    private void Start()
    {
        SpearGameManager.Instance.StateChanged += SpearGameManager_onStateChanged;
        Hide();
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
        gameOver.gameObject.SetActive(true);
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
