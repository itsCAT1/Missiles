using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DataPlane
{
    public int indexPlane;
}

public class DataPlaneManager : MonoBehaviour
{
    public DataPlane dataPlane;

    private void Start()
    {
        LoadDataPlane();
    }

    private void OnApplicationQuit()
    {
        SaveDataPlane();
    }

    [ContextMenu("SaveDataGameplay")]
    public void SaveDataPlane()
    {
        var value = JsonUtility.ToJson(dataPlane);
        PlayerPrefs.SetString(nameof(DataPlane), value);
        PlayerPrefs.Save();
    }

    [ContextMenu("LoadDataGameplay")]
    public void LoadDataPlane()
    {
        var value = JsonUtility.ToJson(dataPlane);
        var dataPlaneValueString = PlayerPrefs.GetString(nameof(DataPlane), value);
        dataPlane = JsonUtility.FromJson<DataPlane>(dataPlaneValueString);
    }
}
