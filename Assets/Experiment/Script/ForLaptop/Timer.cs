using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    float timerTime;
    public float maxTime;
    public GameObject finishPanel;

    private void Start()
    {
        finishPanel.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
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
