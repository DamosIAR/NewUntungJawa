using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Cycle : MonoBehaviour
{
    public TextMeshProUGUI CycleText;
    public GameData gameData;

    private void Start()
    {
        CookGameManager.Instance.OnStateChanged += CookGameManager_OnStateChanged;
    }

    private void Awake()
    {
        gameData = SaveSystem.Load();
        ShowCycle();
    }

    private void CookGameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        if (CookGameManager.Instance.isGameOver())
        {
            gameData.CyclePassed++;
            SaveSystem.Save(gameData);
            Debug.Log(gameData.CyclePassed);
        }
    }

    public void ShowCycle()
    {
        CycleText.text = "Hari ke " + gameData.CyclePassed.ToString();
    }

}
