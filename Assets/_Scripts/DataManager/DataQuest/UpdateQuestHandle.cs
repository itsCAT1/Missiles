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

    private void Start()
    {
        // Khởi tạo Google Play Games
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();

        // Đăng nhập vào Google Play Games
        Social.localUser.Authenticate((bool success) =>
        {
            if (success)
            {
                Debug.Log("Đăng nhập thành công!");
            }
            else
            {
                Debug.Log("Đăng nhập thất bại.");
            }
        });
    }

    public void UpdateQuest()
    {
        var idUpdate = int.Parse(idInput.text);
        var valueUpdate = int.Parse(valueInput.text);

        var questProgress = dataManager.listDataProgress.dataProgresses.Find(questProgress => questProgress.id == idUpdate);

        switch (idUpdate)
        {
            case 0:
                dataManager.dataBase.pointInOneGame = valueUpdate;
                UnlockAchievement("CgkI99L9iJYPEAIQBA"); // Thay "CgkIxxxxxxxxxxxA0" bằng Achievement ID từ Google Play Console
                break;
            case 1:
                dataManager.dataBase.pointInOneGame = valueUpdate;
                UnlockAchievement("CgkI99L9iJYPEAIQBQ");
                break;
                
        }

        dataManager.UpdateValue();
        PlayerPrefs.Save();
    }

    // Hàm để unlock achievement
    public void UnlockAchievement(string achievementID)
    {
        Social.ReportProgress(achievementID, 100.0f, (bool success) =>
        {
            if (success)
            {
                Debug.Log("Achievement unlocked!");
            }
            else
            {
                Debug.Log("Failed to unlock achievement.");
            }
        });
    }

    public void ShowAchievementsUI()
    {
        PlayGamesPlatform.Instance.ShowAchievementsUI();
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
