using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SpearGameManager : MonoBehaviour
{
    public static SpearGameManager Instance { get; private set; }
    public event EventHandler StateChanged;
    public event EventHandler<TimerChangedEventArgs> TimerChanged;

    public class TimerChangedEventArgs : EventArgs { public float timeNormalised; }

    public GameObject[] TutorialImage; // Array of GameObjects to switch between
    private int currentIndex = 0; // Current index of the GameObject array

    private enum State
    {
        Tutorial,
        Countdown,
        GamePlaying,
        GameOver,
    }

    private State state;
    //private float tutorialTime = 3f;
    private float countdownTime = 3f;
    private float gamePlayingTime;
    public float gamePlayingTimeMax = 10f;

    private void Awake()
    {
        Instance = this;
        state = State.Tutorial;
        //getGamePlayingTimerMax();
    }

    private void Update()
    {
        switch (state)
        {
            case State.Tutorial:
                if (TutorialImage.Length > 0)
                {
                    for (int i = 0; i < TutorialImage.Length; i++)
                    {
                        TutorialImage[i].SetActive(i == currentIndex);
                    }
                }
                //tutorialTime -= Time.deltaTime;
                if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    TutorialImage[currentIndex].SetActive(false);

                    currentIndex++;
                    if (currentIndex < TutorialImage.Length)
                    {
                        // Activate the new GameObject
                        TutorialImage[currentIndex].SetActive(true);
                    }
                    else
                    {
                        // Last image reached, change state

                        state = State.Countdown;
                        StateChanged?.Invoke(this, new EventArgs());
                    }
                }
                break;
            case State.Countdown:
                countdownTime -= Time.deltaTime;
                if(countdownTime < 0f)
                {
                    state = State.GamePlaying;
                    gamePlayingTime = gamePlayingTimeMax;
                    StateChanged?.Invoke(this, new EventArgs());
                }
                break;
            case State.GamePlaying:
                gamePlayingTime -= Time.deltaTime;
                if(gamePlayingTime < 0f)
                {
                    state = State.GameOver;
                    StateChanged?.Invoke(this, new EventArgs());
                }
                TimerChanged?.Invoke(this, new TimerChangedEventArgs
                {
                    timeNormalised = 1 - (gamePlayingTime / gamePlayingTimeMax)
                });
                break;
            case State.GameOver:
                break;
        }
    }

    public bool isGamePlaying()
    {
        return state == State.GamePlaying;
    }

    public bool isTutorial()
    {
        return state == State.Tutorial;
    }

    public bool isCountdown()
    {
        return state == State.Countdown;
    }

    public bool isGameOver()
    {
        return state == State.GameOver;
    }

    public float getGamePlayingTimerMax()
    {
        return gamePlayingTime;
    }

    public float getCountdownTimer()
    {
        return countdownTime;
    }
}
