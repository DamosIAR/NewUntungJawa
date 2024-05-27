using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    //[SerializeField] SpearGameManager spearGameManager;
    public TextMeshProUGUI timerText;
    float timerTime;
    public float maxTime;
    [SerializeField] private Canvas finishPanel;

    private void Start()
    {
        SpearGameManager.Instance.StateChanged += SpearGameManager_onStateChanged;
        HideGameOverPanel();
    }

    private void SpearGameManager_onStateChanged(object sender, System.EventArgs e)
    {
        if (SpearGameManager.Instance.isGameOver())
        {
            ShowGameOverPanel();
        }
        else
        {
            HideGameOverPanel();
        }
    }



    private void ShowGameOverPanel()
    {
        Debug.Log("Muncul");
        finishPanel.gameObject.SetActive(true);
    }

    private void HideGameOverPanel()
    {
        Debug.Log("Hilang");
        finishPanel.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!SpearGameManager.Instance.isGamePlaying()) return;
        if (timerTime < maxTime)
        {
            maxTime -= Time.deltaTime;
        }
        else if (timerTime >= maxTime)
        {
            finishPanel.gameObject.SetActive(true);
            maxTime = timerTime;

        }

        int minutes = (int)maxTime / 60;
        int seconds = (int)maxTime % 60;
        timerText.text = string.Format("{00:00} : {01:00}", minutes, seconds);
    }
}
