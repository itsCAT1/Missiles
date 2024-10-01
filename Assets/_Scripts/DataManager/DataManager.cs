using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DataManager : MonoBehaviour
{
    public DataProgress data;
    public DailyQuestDataHandle dailyQuestDataHandle;
    public ListDataProgress listQuestProgress;
    public ListDataQuest listDataQuest;
    public Transform rootUI;

    private void Start()
    {
        LoadData();
        LoadProgress();
        foreach (var quest in listDataQuest.questData)
        {
            DataProgress dataProgress = listQuestProgress.listDataProgress.Find(questProgess => questProgess.id == quest.id);
            CreateQuest(quest, dataProgress);
        }
    }
    private void OnApplicationQuit()
    {
        SaveData();
        SaveProgress();
    }

    void CreateQuest(DailyQuestData dailyQuestData, DataProgress dataBase)
    {
        var quest = Instantiate(dailyQuestDataHandle, rootUI.position, Quaternion.identity);
        quest.transform.SetParent(rootUI);
        quest.SetData(dailyQuestData, dataBase);
    }


    [ContextMenu("SaveData")]
    public void SaveData()
    {
        var value = JsonUtility.ToJson(data);
        PlayerPrefs.SetString(nameof(DataProgress), value);
        PlayerPrefs.Save();
    }

    [ContextMenu("LoadData")]
    public void LoadData()
    {
        var value = JsonUtility.ToJson(data);
        var dataValueString = PlayerPrefs.GetString(nameof(DataProgress), value);
        data = JsonUtility.FromJson<DataProgress>(dataValueString);
    }

    [ContextMenu("SaveProgress")]
    public void SaveProgress()
    {
        var value = JsonUtility.ToJson(listQuestProgress);
        PlayerPrefs.SetString(nameof(ListDataProgress), value);
        PlayerPrefs.Save();
    }

    [ContextMenu("LoadProgress")]
    public void LoadProgress()
    {
        var value = JsonUtility.ToJson(listQuestProgress);
        var dataValueString = PlayerPrefs.GetString(nameof(ListDataProgress), value);
        listQuestProgress = JsonUtility.FromJson<ListDataProgress>(dataValueString);
    }
}
