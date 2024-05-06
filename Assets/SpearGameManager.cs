using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearGameManager : MonoBehaviour
{
    public static SpearGameManager Instance { get; private set; }
    public event EventHandler onStateChanged;

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
    private float gamePlayingTimeMax = 10f;

    private void Start()
    {
        Instance = this;
        state = State.Tutorial;
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
                    onStateChanged?.Invoke(this, new EventArgs());
                }
                break;
            case State.Countdown:
                countdownTime -= Time.deltaTime;
                if(countdownTime < 0f)
                {
                    state = State.GamePlaying;
                    gamePlayingTime = gamePlayingTimeMax;
                    onStateChanged?.Invoke(this, new EventArgs());
                }
                break;
            case State.GamePlaying:
                gamePlayingTime -= Time.deltaTime;
                if(gamePlayingTime < 0f)
                {
                    state = State.GameOver;
                    onStateChanged?.Invoke(this, new EventArgs());
                }
                break;
            case State.GameOver:
                onStateChanged?.Invoke(this, new EventArgs());
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
}
