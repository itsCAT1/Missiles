using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateQuestHandle : MonoBehaviour
{
    public InputField valueInput;
    public InputField idInput;
    public DataManager dataManager;

    public void UpdateQuest()
    {
        var idUpdate = int.Parse(idInput.text);
        var valueUpdate = int.Parse(valueInput.text);

        var questProgress = dataManager.listDataProgress.dataProgresses.Find(questProgress => questProgress.id == idUpdate);


        switch (idUpdate)
        {
            case 0:
                dataManager.dataBase.pointInOneGame = valueUpdate;
                break;
            case 1:
                dataManager.dataBase.pointInOneGame = valueUpdate;
                break;
            case 2:
                dataManager.dataBase.pointInOneGame = valueUpdate;
                break;
            case 3:
                dataManager.dataBase.bestScoreFastMode = valueUpdate;
                break;
            case 4:
                dataManager.dataBase.starInOneGame = valueUpdate;
                break;
            case 5:
                dataManager.dataBase.starInOneGame = valueUpdate;
                break;
            case 6:
                dataManager.dataBase.starInOneGame = valueUpdate;
                break;
            case 7:
                dataManager.dataBase.totalStar = valueUpdate;
                break;
            case 8:
                dataManager.dataBase.totalStar = valueUpdate;
                break;
            case 9:
                dataManager.dataBase.totalStar = valueUpdate;
                break;
            case 10:
                dataManager.dataBase.totalShield = valueUpdate;
                break;
            case 11:
                dataManager.dataBase.totalSpeedUp = valueUpdate;
                break;
            case 12:
                dataManager.dataBase.totalPlane = valueUpdate;
                break;
            case 13:
                dataManager.dataBase.totalGame = valueUpdate;
                break;
            case 14:
                dataManager.dataBase.totalGame = valueUpdate;
                break;
            case 15:
                dataManager.dataBase.totalGame = valueUpdate;
                break;
        }

        dataManager.UpdateValue();
        PlayerPrefs.Save();
    }

    public void Reset()
    {
        PlayerPrefs.DeleteAll();

        dataManager.dataBase = new DataBase();
        dataManager.UpdateValue();

        dataManager.SaveDataBase();
        dataManager.SaveDataProgress();

    }

}
