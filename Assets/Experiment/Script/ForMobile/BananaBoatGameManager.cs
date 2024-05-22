using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaBoatGameManager : MonoBehaviour
{
    public static BananaBoatGameManager Instance { get; private set; }

    public event EventHandler OnStateChanged;

    private enum State
    {
        Tutorial,
        CountdownToStart,
        Playing,
        GameOver,
    }

    private State state;
    private float countdownToStartTimer = 3f;
    private float timeElapsed;

    private void Awake()
    {
        Instance = this;
        state = State.Tutorial;
        
    }

    private void Update()
    {
        switch (state)
        {
            case State.Tutorial:
                if(Input.touchCount > 0)
                {
                    state = State.CountdownToStart;
                    OnStateChanged?.Invoke(this, new EventArgs());
                }
                break;
            case State.CountdownToStart:
                countdownToStartTimer -= Time.deltaTime;
                if(countdownToStartTimer == 0)
                {
                    state = State.Playing;
                    OnStateChanged?.Invoke(this, new EventArgs());
                    
                }
                break;
            case State.Playing:
                timeElapsed += Time.deltaTime;
                if(BBPlayerStateManager.Instance.getRidingState())
                {

                }
                else
                {
                    state = State.GameOver;
                    OnStateChanged?.Invoke(this, new EventArgs());
                }
                break;
            case State.GameOver:
                break;
        }
    }
}
