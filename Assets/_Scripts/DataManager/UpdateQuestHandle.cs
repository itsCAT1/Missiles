using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateQuestHandle : MonoBehaviour
{
    public InputField valueInput;
    public InputField idInput;
    public DataManager questDataManager;

    public void UpdateQuest()
    {
        var idUpdate = int.Parse(idInput.text);
        var valueUpdate = int.Parse(valueInput.text);

        var questProgress = questDataManager.listDataProgress.dataProgresses.Find(questProgress => questProgress.id == idUpdate);

        questProgress.currentValue = valueUpdate;

        switch (idUpdate)
        {
            case 0:
                questDataManager.dataBase.pointInOneGame = valueUpdate;
                break;
            case 1:
                questDataManager.dataBase.pointInOneGame = valueUpdate;
                break;
            case 2:
                questDataManager.dataBase.pointInOneGame = valueUpdate;
                break;
            case 3:
                questDataManager.dataBase.bestScoreFastMode = valueUpdate;
                break;
            case 4:
                questDataManager.dataBase.starInOneGame = valueUpdate;
                break;
            case 5:
                questDataManager.dataBase.starInOneGame = valueUpdate;
                break;
            case 6:
                questDataManager.dataBase.starInOneGame = valueUpdate;
                break;
            case 7:
                questDataManager.dataBase.totalStar = valueUpdate;
                break;
            case 8:
                questDataManager.dataBase.totalStar = valueUpdate;
                break;
            case 9:
                questDataManager.dataBase.totalStar = valueUpdate;
                break;
            case 10:
                questDataManager.dataBase.totalShield = valueUpdate;
                break;
            case 11:
                questDataManager.dataBase.totalSpeedUp = valueUpdate;
                break;
            case 12:
                questDataManager.dataBase.totalPlane = valueUpdate;
                break;
            case 13:
                questDataManager.dataBase.totalGame = valueUpdate;
                break;
            case 14:
                questDataManager.dataBase.totalGame = valueUpdate;
                break;
            case 15:
                questDataManager.dataBase.totalGame = valueUpdate;
                break;
        }

        questDataManager.UpdateValue(questProgress);
        PlayerPrefs.Save();
    }

    public void Reset()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log(questDataManager.dataBase.pointInOneGame);
        questDataManager.LoadDataBase();

        for (int i = 0; i < questDataManager.listDataProgress.dataProgresses.Count; i++)
        {
            var questProgress = questDataManager.listDataProgress.dataProgresses[i];
            questProgress.currentValue = 0;
            questDataManager.UpdateValue(questProgress);
        }
        Debug.Log(questDataManager.dataBase.pointInOneGame);
    }

}
