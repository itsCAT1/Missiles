using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class UpdateQuestHandle : MonoBehaviour
{
    public InputField valueInput;
    public InputField idInput;
    public DataManager dataManager;
    public AchievementHandler achievementHandler;

    public void UpdateQuest()
    {
        var idUpdate = int.Parse(idInput.text);
        var valueUpdate = int.Parse(valueInput.text);

        var questProgress = dataManager.listDataProgress.dataProgresses.Find(questProgress => questProgress.id == idUpdate);

        float currentProgress = (float)dataManager.listDataProgress.dataProgresses[idUpdate].currentValue /
                dataManager.listDataQuest.questData[idUpdate].valueTarget;
        switch (idUpdate)
        {
            case 0:
                dataManager.dataBase.pointInOneGame = valueUpdate;
                achievementHandler.UnlockAchievement("CgkI99L9iJYPEAIQBA", currentProgress);
                break;
            case 1:
                dataManager.dataBase.pointInOneGame = valueUpdate;
                achievementHandler.UnlockAchievement("CgkI99L9iJYPEAIQDg", currentProgress);
                break;
            case 2:
                dataManager.dataBase.pointInOneGame = valueUpdate;
                achievementHandler.UnlockAchievement("CgkI99L9iJYPEAIQEA", currentProgress);
                break;
            case 3:
                dataManager.dataBase.bestScoreFastMode = valueUpdate;
                achievementHandler.UnlockAchievement("CgkI99L9iJYPEAIQDw", currentProgress);
                break;
            case 4:
                dataManager.dataBase.starInOneGame = valueUpdate;
                achievementHandler.UnlockAchievement("CgkI99L9iJYPEAIQBQ", currentProgress);
                break;
            case 5:
                dataManager.dataBase.starInOneGame = valueUpdate;
                achievementHandler.UnlockAchievement("CgkI99L9iJYPEAIQBg", currentProgress);
                break;
            case 6:
                dataManager.dataBase.starInOneGame = valueUpdate;
                achievementHandler.UnlockAchievement("CgkI99L9iJYPEAIQBw", currentProgress);
                break;
            case 7:
                dataManager.dataBase.totalStar = valueUpdate;
                achievementHandler.UnlockAchievement("CgkI99L9iJYPEAIQCA", currentProgress);
                break;
            case 8:
                dataManager.dataBase.totalStar = valueUpdate;
                achievementHandler.UnlockAchievement("CgkI99L9iJYPEAIQEQ", currentProgress);
                break;
            case 9:
                dataManager.dataBase.totalStar = valueUpdate;
                achievementHandler.UnlockAchievement("CgkI99L9iJYPEAIQEg", currentProgress);
                break;
            case 10:
                dataManager.dataBase.totalShield = valueUpdate;
                achievementHandler.UnlockAchievement("CgkI99L9iJYPEAIQCQ", currentProgress);
                break;
            case 11:
                dataManager.dataBase.totalSpeedUp = valueUpdate;
                achievementHandler.UnlockAchievement("CgkI99L9iJYPEAIQCg", currentProgress);
                break;
            case 12:
                dataManager.dataBase.totalPlane = valueUpdate;
                achievementHandler.UnlockAchievement("CgkI99L9iJYPEAIQCw", currentProgress);
                break;
            case 13:
                dataManager.dataBase.totalGame = valueUpdate;
                achievementHandler.UnlockAchievement("CgkI99L9iJYPEAIQDA", currentProgress);
                break;
            case 14:
                dataManager.dataBase.totalGame = valueUpdate;
                achievementHandler.UnlockAchievement("CgkI99L9iJYPEAIQDQ", currentProgress);
                break;
            case 15:
                dataManager.dataBase.totalGame = valueUpdate;
                achievementHandler.UnlockAchievement("CgkI99L9iJYPEAIQEw", currentProgress);
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
