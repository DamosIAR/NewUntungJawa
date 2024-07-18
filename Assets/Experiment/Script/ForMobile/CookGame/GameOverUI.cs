using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI GameOverText;
    [SerializeField] private Canvas GameOverCanvas;
    [SerializeField] private TextMeshProUGUI RecipeDeliveredText;
    [SerializeField] private TextMeshProUGUI RecipeFailedText;
    /*[SerializeField] private TextMeshProUGUI CoinText;
    [SerializeField] private TextMeshProUGUI TotalCoin;
    public int currentCoin;
    public int totalcoin;*/

    public GameData gameData;

    private void Start()
    {
        CookGameManager.Instance.OnStateChanged += CookGameManager_OnStateChanged;
        hide();
    }

    private void Awake()
    {
        gameData = SaveSystem.Load();
    }

    private void CookGameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        if (CookGameManager.Instance.isGameOver())
        {
            show();
            RecipeDeliveredText.text = "Masakan Benar : " + DeliveryManager.Instance.GetSuccessfulDeliveryAmount().ToString();
            RecipeFailedText.text = "Masakan Salah : " + DeliveryManager.Instance.GetFaildeDeliveryAmount().ToString();
            /*CoinText.text = "Koin Hari Ini : " + DeliveryManager.Instance.GetCoinAmount().ToString();
            TotalCoin.text = "Total Koin : " + gameData.Totalmoney.ToString();*/
            gameData.Totalmoney += DeliveryManager.Instance.GetCoinAmount();
            SaveSystem.Save(gameData);


        }
        else
        {
            hide();
        }

    }


    public void show()
    {
        gameObject.SetActive(true);
    }

    private void hide()
    {
        gameObject.SetActive(false);
    }

}
