using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CookGameManager : MonoBehaviour
{
    public static CookGameManager Instance { get; private set; }

    public event EventHandler OnStateChanged;

    private enum State
    {
        WaitingToStart,
        CountdownToStart,
        GamePlaying,
        GameOver,
    }

    private State state;
    private float waitingToStartTimer = 2f;
    private float countdownToStartTimer = 3f;
    private float gamePlayingTimer = 10f;

    private void Awake()
    {
        Instance = this;
        state = State.WaitingToStart;
    }

    private void Update()
    {
        switch (state)
        {
            case State.WaitingToStart:
                waitingToStartTimer -= Time.deltaTime;
                if(waitingToStartTimer < 0f)
                {
                    state = State.CountdownToStart;
                    OnStateChanged?.Invoke(this, new EventArgs());
                }
                break;
            case State.CountdownToStart:
                countdownToStartTimer -= Time.deltaTime;
                if (countdownToStartTimer < 0f)
                {
                    state = State.GamePlaying;
                    OnStateChanged?.Invoke(this, new EventArgs());
                }
                break;
            case State.GamePlaying:
                gamePlayingTimer -= Time.deltaTime;
                if (gamePlayingTimer < 0f)
                {
                    state = State.GameOver;
                    OnStateChanged?.Invoke(this, new EventArgs());
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

    public bool isCountdownToStartActive()
    {
        return state == State.CountdownToStart;
    }

    public bool isWaitingToStartActive()
    {
        return state == State.WaitingToStart;
    }

    public float GetCountdownToStartTimer()
    {
        return countdownToStartTimer;
    }
}
