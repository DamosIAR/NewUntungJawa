using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GalleryGameManager : MonoBehaviour
{
    private GameData gameData;

    public TextMeshProUGUI Money;
    public TextMeshProUGUI Cycle;

    private void Awake()
    {
        gameData = SaveSystem.Load();
        RefreshUI();
    }

    void RefreshUI()
    {
        Money.text = gameData.Totalmoney.ToString();
        Cycle.text = "Hari Ke " + gameData.CyclePassed.ToString();

    }
}
