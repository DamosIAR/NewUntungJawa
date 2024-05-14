using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public TextMeshProUGUI CoinText;
    public TextMeshProUGUI TotalCoin;
    public int currentCoin;
    public int totalcoin;


    // Update is called once per frame
    void Update()
    {
        savedCoin();
    }

    public void savedCoin()
    {

        currentCoin = DeliveryManager.Instance.GetCoinAmount();
        CoinText.text = "This Session Coin : " + currentCoin.ToString();
        TotalCoin.text = "Your Total Coin : " + totalcoin.ToString();
    }




}
