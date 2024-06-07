using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class BBTimer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI CountdownText;
    void Start()
    {
        BananaBoatGameManager.Instance.OnStateChanged += BananaBoatGameManager_OnStateChanged;
        HideCountdown();
    }

    private void BananaBoatGameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        if (BananaBoatGameManager.Instance.isCountown())
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
        CountdownText.text = Mathf.Ceil(BananaBoatGameManager.Instance.GetCountdown()).ToString();
    }

    private void ShowCountdown()
    {
        CountdownText.gameObject.SetActive(true);
    }

    private void HideCountdown()
    {
        CountdownText.gameObject.SetActive(false);
    }
}
