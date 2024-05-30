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
    public int currentCoin;
    public int totalcoin;

    public GameData gameData;

    private void Awake()
    {
        gameData = SaveSystem.Load();
    }

    // Update is called once per frame
    void Update()
    {
        savedCoin();
    }

    public void savedCoin()
    {
        CoinText.text = "This Session Coin : " + DeliveryManager.Instance.GetCoinAmount().ToString();
        TotalCoin.text = "Your Total Coin : " + gameData.Totalmoney.ToString();
    }
}
