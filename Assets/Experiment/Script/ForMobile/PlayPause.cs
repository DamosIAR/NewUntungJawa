using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayPause : MonoBehaviour
{
    [SerializeField] private GameObject PauseButton;
    [SerializeField] private GameObject PauseMenu;
    [SerializeField] private GameObject Barrier;
    [SerializeField] private GameObject MenuConfirmation;

    public event EventHandler onStateChanged;

    private bool isPaused;

    private void Start()
    {
        PauseMenu.SetActive(false);
        PauseButton.SetActive(true);
        Barrier.SetActive(false);
        MenuConfirmation.SetActive(false);
        isPaused = false;
    }

    public void ContinueGame()
    {
        PauseMenu.SetActive(false );
        PauseButton.SetActive(true);
        Barrier.SetActive(false);
        isPaused = false;
        MenuConfirmation.SetActive(false);
        Time.timeScale = 1f;
    }

    public void PauseGame()
    {
        PauseMenu.SetActive(true );
        PauseButton.SetActive(false);
        Barrier.SetActive(true);
        MenuConfirmation.SetActive(false);
        isPaused = true;
        Time.timeScale = 0f;
    }

    public void Mainmenu()
    {
        MenuConfirmation.SetActive(true );
    }

    public void MainmenuYes()
    {
        gameObject.SetActive(false);
    }

    public void MainmenuNo()
    {
        MenuConfirmation.SetActive(false ) ;
    }

}
