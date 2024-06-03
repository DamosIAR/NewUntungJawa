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
        gameData = SaveSystem.Load();
        CookGameManager.Instance.OnStateChanged += CookGameManager_OnStateChanged;
        Debug.Log("Yang di load: " + gameData.CyclePassed);
        ShowCycle();
    }

    private void CookGameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        if (CookGameManager.Instance.isGameOver())
        {
            gameData.CyclePassed++;
            SaveSystem.Save(gameData);
            Debug.Log("Yand Di save: " + gameData.CyclePassed);
            ShowCycle();
        }
    }

    public void ShowCycle()
    {
        gameData = SaveSystem.Load();
        CycleText.text = "Hari ke " + gameData.CyclePassed.ToString();
    }

}
