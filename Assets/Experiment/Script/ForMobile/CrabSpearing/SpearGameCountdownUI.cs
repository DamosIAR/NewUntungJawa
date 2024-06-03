using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpearGameCountdownUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countdownUI;
    [SerializeField] private GameObject helpCanvas;


    // Start is called before the first frame update
    void Start()
    {
        SpearGameManager.Instance.StateChanged += SpearGameManager_StateChanged;
    }

    private void SpearGameManager_StateChanged(object sender, System.EventArgs e)
    {
        if(SpearGameManager.Instance.isTutorial())
        {
            showHelp();
        }
        else
        {
            hideHelp();
        }

        if (SpearGameManager.Instance.isCountdown())
        {
            showText();
        }
        else
        {
            hideText();
        }
    }

    // Update is called once per frame
    void Update()
    {
        countdownUI.text = Mathf.Ceil(SpearGameManager.Instance.getCountdownTimer()).ToString();
    }

    private void showText()
    {
        countdownUI.gameObject.SetActive(true);
    }

    private void hideText()
    {
        countdownUI.gameObject.SetActive(false);
    }

    private void showHelp()
    {
        helpCanvas.gameObject.SetActive(true);
    }

    private void hideHelp()
    {
        helpCanvas.gameObject.SetActive(false);
    }
}
