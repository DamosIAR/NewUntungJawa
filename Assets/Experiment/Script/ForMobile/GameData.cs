using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int money;

    public string ToJSon()
    {
        return JsonUtility.ToJson(this);
    }

    public void LoadFromJson(string json)
    {
        JsonUtility.FromJsonOverwrite(json, this);
    }
}

public interface ISaveable
{
    void PopulateSaveData(GameData gameData);
    void LoadFromSaveData(GameData gameData);
}
