using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanaBoatUI : MonoBehaviour
{
    [SerializeField] private GameObject Help;
    [SerializeField] private GameObject GameOver;
    [SerializeField] private GameObject TXT;

    public GameData gameData;
    private int scoreToConvert = (int)BBScoreManager.Instance.GetCurrentScore();

    private void Start()
    {
        gameData = SaveSystem.Load();
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
            gameData.Totalmoney += (scoreToConvert * 2);
            SaveSystem.Save(gameData);
            ShowGameOverUI();
            hideTXT();
        }
        else
        {
            HideGameOverUI();
            showTXT();
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

    private void showTXT()
    {
        TXT.gameObject.SetActive(true);
    }

    private void hideTXT()
    {
        TXT.gameObject.SetActive(false);
    }
}
