using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CoinManager : MonoBehaviour
{
    public TextMeshProUGUI CoinText;
    public TextMeshProUGUI TotalCoin;
    private int currentCoin;
    private int totalcoin;

    public GameData gameData;

    private void Start()
    {
        gameData = SaveSystem.Load();
        CookGameManager.Instance.OnStateChanged += CookGameManager_OnStateChanged;
    }

    private void CookGameManager_OnStateChanged(object sender, EventArgs e)
    {
        if (CookGameManager.Instance.isGameOver())
        {
            gameData.Totalmoney += DeliveryManager.Instance.GetCoinAmount();
            SaveSystem.Save(gameData);
            savedCoin();
            Debug.Log(gameData.Totalmoney);
        }
    }

    public void savedCoin()
    {
        CoinText.text = "This Session Coin : " + DeliveryManager.Instance.GetCoinAmount().ToString();
        TotalCoin.text = "Your Total Coin : " + gameData.Totalmoney.ToString();
    }
}
