using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpearGameManager : MonoBehaviour
{
    public static SpearGameManager Instance { get; private set; }
    public event EventHandler StateChanged;

    private enum State
    {
        Tutorial,
        Countdown,
        GamePlaying,
        GameOver,
    }

    private State state;
    private float tutorialTime = 3f;
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
                tutorialTime -= Time.deltaTime;
                if(tutorialTime < 0f)
                {
                    state = State.Countdown;
                    StateChanged?.Invoke(this, new EventArgs());
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


}
