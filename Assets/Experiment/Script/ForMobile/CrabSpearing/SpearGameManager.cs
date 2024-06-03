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

    public GameObject[] gameObjects; // Array of GameObjects to switch between
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
                if (gameObjects.Length > 0)
                {
                    for (int i = 0; i < gameObjects.Length; i++)
                    {
                        gameObjects[i].SetActive(i == currentIndex);
                    }
                }
                //tutorialTime -= Time.deltaTime;
                if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    gameObjects[currentIndex].SetActive(false);

                    currentIndex++;
                    if (currentIndex < gameObjects.Length)
                    {
                        // Activate the new GameObject
                        gameObjects[currentIndex].SetActive(true);
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
