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

    // Start is called before the first frame update
    void Start()
    {

        CoinText.text = "Your Total Coin : " + totalcoin.ToString();
        //totalcoin = currentCoin;
    }

    // Update is called once per frame
    void Update()
    {
        savedCoin();
    }

    public void savedCoin()
    {

        currentCoin = DeliveryManager.Instance.GetCoinAmount();
        CoinText.text = "This Session Coin : " + currentCoin.ToString();
        PlayerPrefs.GetInt("Coin", currentCoin);
        //totalcoin = currentCoin;

        totalcoin = PlayerPrefs.GetInt("coin", currentCoin);
        PlayerPrefs.SetInt("Coin", totalcoin);
        TotalCoin.text = "Your Total Coin : " + totalcoin.ToString();
    }

}
