using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DataManager : MonoBehaviour
{
    public DataBase dataBase;
    public DailyQuestDataHandle dailyQuestDataHandle;
    public ListDataProgress listDataProgress;
    public ListDataQuest listDataQuest;
    public Transform rootUI;
    public Dictionary<int, DailyQuestDataHandle> uiHandlerDict;

    private void Awake()
    {
        LoadDataProgress();
        LoadDataBase();
        
        uiHandlerDict = new Dictionary<int, DailyQuestDataHandle>();
        foreach (var quest in listDataQuest.questData)
        {
            DataProgress dataProgress = listDataProgress.dataProgresses.
                Find(questProrgess => questProrgess.id == quest.id);
            CreateQuest(quest, dataProgress);
        }
    }

    private void OnApplicationQuit()
    {
        SaveDataBase();
        SaveDataProgress();
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            SaveDataBase();
            SaveDataProgress();
        }
    }

    void CreateQuest(DailyQuestData dailyQuestData, DataProgress dataProgress)
    {
        var quest = Instantiate(dailyQuestDataHandle, rootUI);
        
        quest.SetData(dailyQuestData, dataProgress);
        uiHandlerDict.Add(dataProgress.id, quest);
    }

    public void UpdateValue()
    {
        UpdateValueDataProgress();
        foreach (var dataProgress in listDataProgress.dataProgresses)
        {
            uiHandlerDict[dataProgress.id].SetDataProgress(dataProgress);
        }
    }


    [ContextMenu("SaveDataBase")]
    public void SaveDataBase()
    {
        var value = JsonUtility.ToJson(dataBase);
        PlayerPrefs.SetString(nameof(DataBase), value);
        UpdateValueDataProgress();
        PlayerPrefs.Save();
    }

    [ContextMenu("LoadDataBase")]
    public void LoadDataBase()
    {
        var value = JsonUtility.ToJson(dataBase);
        var dataValueString = PlayerPrefs.GetString(nameof(DataBase), value);
        dataBase = JsonUtility.FromJson<DataBase>(dataValueString);
        UpdateValueDataProgress();
    }

    [ContextMenu("SaveProgress")]
    public void SaveDataProgress()
    {
        var value = JsonUtility.ToJson(listDataProgress);
        PlayerPrefs.SetString(nameof(ListDataProgress), value);
        PlayerPrefs.Save();
    }

    [ContextMenu("LoadProgress")]
    public void LoadDataProgress()
    {
        var value = JsonUtility.ToJson(listDataProgress);
        var dataValueString = PlayerPrefs.GetString(nameof(ListDataProgress), value);
        listDataProgress = JsonUtility.FromJson<ListDataProgress>(dataValueString);
    }

    public void UpdateValueDataProgress()
    {
        listDataProgress.dataProgresses[0].currentValue = dataBase.pointInOneGame;
        listDataProgress.dataProgresses[1].currentValue = dataBase.pointInOneGame;
        listDataProgress.dataProgresses[2].currentValue = dataBase.pointInOneGame;
        listDataProgress.dataProgresses[3].currentValue = dataBase.bestScoreFastMode;
        listDataProgress.dataProgresses[4].currentValue = dataBase.starInOneGame;
        listDataProgress.dataProgresses[5].currentValue = dataBase.starInOneGame;
        listDataProgress.dataProgresses[6].currentValue = dataBase.starInOneGame;
        listDataProgress.dataProgresses[7].currentValue = dataBase.totalStar;
        listDataProgress.dataProgresses[8].currentValue = dataBase.totalStar;
        listDataProgress.dataProgresses[9].currentValue = dataBase.totalStar;
        listDataProgress.dataProgresses[10].currentValue = dataBase.totalShield;
        listDataProgress.dataProgresses[11].currentValue = dataBase.totalSpeedUp;
        listDataProgress.dataProgresses[12].currentValue = dataBase.totalPlane;
        listDataProgress.dataProgresses[13].currentValue = dataBase.totalGame;
        listDataProgress.dataProgresses[14].currentValue = dataBase.totalGame;
        listDataProgress.dataProgresses[15].currentValue = dataBase.totalGame;
    }
}
