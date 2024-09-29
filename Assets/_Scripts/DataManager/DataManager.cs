using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Data
{
    public int indexPlane;
    public int indexGameMode;
    public int indexGameControl;
    public int coin;
}

public class DataManager : MonoBehaviour
{
    public Data data;

    private void Start()
    {
        LoadData();
    }

    private void OnApplicationQuit()
    {
        SaveData();
    }

    [ContextMenu("SaveData")]
    public void SaveData()
    {
        var value = JsonUtility.ToJson(data);
        PlayerPrefs.SetString(nameof(Data), value);
        PlayerPrefs.Save();
    }

    [ContextMenu("LoadData")]
    public void LoadData()
    {
        var value = JsonUtility.ToJson(data);
        var dataValueString = PlayerPrefs.GetString(nameof(Data), value);
        data = JsonUtility.FromJson<Data>(dataValueString);
    }
}
