using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CookGameManager : MonoBehaviour
{
    public static CookGameManager Instance { get; private set; }

    public event EventHandler<OnTimerChangedEventArgs> OnTimerChanged;
    public class OnTimerChangedEventArgs : EventArgs { public float TimeNormalised; }

    public event EventHandler OnStateChanged;
    public event EventHandler OnGateMove;
    public event EventHandler OnTimeAboutToEnd;

    //public GameData gameData;
    //bool TimerWarning = false;

    private enum State
    {
        WaitingToStart,
        CountdownToStart,
        GamePlaying,
        GameOver,
    }

    private State state;
    //private float waitingToStartTimer = 2f;
    private float countdownToStartTimer = 3f;
    private float gamePlayingTimer;
    private float gamePlayingTimerMax = 15f;

    private void Awake()
    {
        Instance = this;
        state = State.WaitingToStart;
        //gameData = SaveSystem.Load();
    }

    private void Update()
    {
        switch (state)
        {
            case State.WaitingToStart:
                //waitingToStartTimer -= Time.deltaTime;
                if(Input.touchCount > 0f)
                {
                    state = State.CountdownToStart;
                    OnStateChanged?.Invoke(this, new EventArgs());
                    OnGateMove?.Invoke(this, new EventArgs());
                }
                break;
            case State.CountdownToStart:
                countdownToStartTimer -= Time.deltaTime;
                if (countdownToStartTimer < 0f)
                {
                    state = State.GamePlaying;
                    gamePlayingTimer = gamePlayingTimerMax;
                    OnStateChanged?.Invoke(this, new EventArgs());
                }
                break;
            case State.GamePlaying:
                gamePlayingTimer -= Time.deltaTime;
                if(gamePlayingTimer <= 10f && gamePlayingTimer >= 9.99f)
                {
                    OnTimeAboutToEnd?.Invoke(this, EventArgs.Empty);
                }
                if (gamePlayingTimer < 0f)
                {
                    state = State.GameOver;
                    OnStateChanged?.Invoke(this, new EventArgs());
                    OnGateMove?.Invoke(this, new EventArgs());
                }
                OnTimerChanged?.Invoke(this, new OnTimerChangedEventArgs
                {
                    TimeNormalised = 1 - (gamePlayingTimer/gamePlayingTimerMax)
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

    public bool isCountdownToStartActive()
    {
        return state == State.CountdownToStart;
    }

    public bool isWaitingToStartActive()
    {
        return state == State.WaitingToStart;
    }

    public bool isGameOver()
    {
        return state == State.GameOver;
    }

    public float GetCountdownToStartTimer()
    {
        return countdownToStartTimer;
    }

    public float getRemainingTimer()
    {
        return gamePlayingTimer;
    }
}
