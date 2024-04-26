using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI balance;
    private int money;

    public void addMoney()
    {
        money += 10000;
        balance.text = "" + money;
    }

}
