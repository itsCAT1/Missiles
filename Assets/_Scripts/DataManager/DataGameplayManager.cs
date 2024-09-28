using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class DataGameplay
{
    public int indexGameMode;
    public int indexGameControl;
}


public class DataGameplayManager : MonoBehaviour
{
    public DataGameplay dataGameplay;

    private void Start()
    {
        LoadDataGameplay();
    }

    private void OnApplicationQuit()
    {
        SaveDataGameplay();
    }

    [ContextMenu("SaveDataGameplay")]
    public void SaveDataGameplay()
    {
        var value = JsonUtility.ToJson(dataGameplay);
        PlayerPrefs.SetString(nameof(DataGameplay), value);
        PlayerPrefs.Save();
    }

    [ContextMenu("LoadDataGameplay")]
    public void LoadDataGameplay()
    {
        var value = JsonUtility.ToJson(dataGameplay);
        var dataGameplayValueString = PlayerPrefs.GetString(nameof(DataGameplay), value);
        dataGameplay = JsonUtility.FromJson<DataGameplay>(dataGameplayValueString);
    }
}
