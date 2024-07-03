using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameStartCountdownUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countdownText;
    [SerializeField] private Canvas HelpCanvas;

    private void Start()
    {
        CookGameManager.Instance.OnStateChanged += CookGameManager_OnStateChanged;
        HideCountdown();
    }

    private void CookGameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        if (CookGameManager.Instance.isWaitingToStartActive())
        {
            ShowHelp();
        }
        else
        {
            HideHelp();
        }


        if (CookGameManager.Instance.isCountdownToStartActive())
        {
            ShowCountdown();
        }
        else
        {
            HideCountdown();
        }
    }

    private void Update()
    {
        countdownText.text = Mathf.Ceil( CookGameManager.Instance.GetCountdownToStartTimer()).ToString();
    }

    private void ShowCountdown()
    {
        countdownText.gameObject.SetActive(true);
    }

    private void HideCountdown()
    {
        countdownText.gameObject.SetActive(false);
    }

    private void ShowHelp()
    {
        HelpCanvas.gameObject.SetActive(true);
    }

    private void HideHelp()
    {
        HelpCanvas.gameObject.SetActive(false);
    }


}
