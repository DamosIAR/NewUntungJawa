using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanaBoatUI : MonoBehaviour
{
    [SerializeField] private GameObject Help;
    [SerializeField] private GameObject GameOver;

    private void Start()
    {
        BananaBoatGameManager.Instance.OnStateChanged += BananaBoatGameManager_OnStateChanged;
        HideGameOverUI();
    }

    private void BananaBoatGameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        if (BananaBoatGameManager.Instance.isTutorial())
        {
            ShowHelpUI();
        }
        else
        {
            HideHelpUI();
        }

        if (BananaBoatGameManager.Instance.isGameOver())
        {
            ShowGameOverUI();
        }
        else
        {
            HideGameOverUI();
        }
    }

    private void ShowHelpUI()
    {
        Help.gameObject.SetActive(true);
    }

    private void HideHelpUI()
    {
        Help.gameObject.SetActive(false);
    }

    private void ShowGameOverUI()
    {
        GameOver.gameObject.SetActive(true);
    }

    private void HideGameOverUI()
    {
        GameOver.gameObject.SetActive(false);
    }
}
