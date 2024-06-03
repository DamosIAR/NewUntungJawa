using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int Totalmoney;
    public int CyclePassed;

    public GameData()
    {
        Totalmoney = 0;
        CyclePassed = 1;
    }
}
