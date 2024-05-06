using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TimerText;
    [SerializeField] private Canvas gameOver;

    private void Start()
    {
        SpearGameManager.Instance.onStateChanged += SpearGameManager_onStateChanged;
    }

    private void SpearGameManager_onStateChanged(object sender, System.EventArgs e)
    {
        if (SpearGameManager.Instance.isGamePlaying())
        {
            Debug.Log("Main");
        }
    }
}
