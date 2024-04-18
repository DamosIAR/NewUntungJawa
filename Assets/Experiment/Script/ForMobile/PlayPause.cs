using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayPause : MonoBehaviour
{
    [SerializeField] private GameObject PauseButton;
    [SerializeField] private GameObject PauseMenu;
    [SerializeField] private GameObject Barrier;

    private bool isPaused;

    private void Start()
    {
        PauseMenu.SetActive(false);
        PauseButton.SetActive(true);
        Barrier.SetActive(false);
        isPaused = false;
    }

    public void ContinueGame()
    {
        PauseMenu.SetActive(false );
        PauseButton.SetActive(true);
        Barrier.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f;
    }

    public void PauseGame()
    {
        PauseMenu.SetActive(true );
        PauseButton.SetActive(false);
        Barrier.SetActive(true);
        isPaused = true;
        Time.timeScale = 0f;
    }

}
