using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayPause : MonoBehaviour
{
    [SerializeField] private GameObject PauseButton;
    [SerializeField] private GameObject PauseMenu;

    private void Start()
    {
        PauseMenu.SetActive(false);
        PauseButton.SetActive(true);
    }

    public void ContinueGame()
    {
        PauseMenu.SetActive(false );
        PauseButton.SetActive(true);
    }

    public void PauseGame()
    {
        PauseMenu.SetActive(true );
        PauseButton.SetActive(false);
    }

}
