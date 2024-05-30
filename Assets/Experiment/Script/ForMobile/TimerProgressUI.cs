using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerProgressUI : MonoBehaviour
{
    [SerializeField] CookGameManager cookGameManager;
    [SerializeField] private Image timerImage;

    private AudioSource timerAudioSource;

    private void Awake()
    {
        timerAudioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        cookGameManager.OnTimerChanged += CookGameManager_OnTimerChanged;
        //timerImage.fillAmount = 1;
    }

    private void CookGameManager_OnTimerChanged(object sender, CookGameManager.OnTimerChangedEventArgs e)
    {
        timerImage.fillAmount = e.TimeNormalised;
        
    }
}
