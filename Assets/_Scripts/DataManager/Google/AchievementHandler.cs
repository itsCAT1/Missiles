using GooglePlayGames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AchievementHandler : MonoBehaviour
{
    public DataManager dataManager;

    public void UnlockAchievement(string achievementID, float progressPercentage)
    {
        // Báo cáo phần trăm hoàn thành của achievement
        Social.ReportProgress(achievementID, progressPercentage * 100, (bool success) =>
        {
            if (success)
            {
                Debug.Log("Update progress success");
            }
            else
            {
                Debug.Log("Update progress fail");
            }
        });
    }

    public void ShowAchievementsUI()
    {
        PlayGamesPlatform.Instance.ShowAchievementsUI();
    }

    public void ShowAchievementProgress()
    {
        string[] achievementIDs = {
        "CgkI99L9iJYPEAIQBA",
        "CgkI99L9iJYPEAIQDg",
        "CgkI99L9iJYPEAIQEA",
        "CgkI99L9iJYPEAIQDw",
        "CgkI99L9iJYPEAIQBQ",
        "CgkI99L9iJYPEAIQBg",
        "CgkI99L9iJYPEAIQBw",
        "CgkI99L9iJYPEAIQCA",
        "CgkI99L9iJYPEAIQEQ",
        "CgkI99L9iJYPEAIQEg",
        "CgkI99L9iJYPEAIQCQ",
        "CgkI99L9iJYPEAIQCg",
        "CgkI99L9iJYPEAIQCw",
        "CgkI99L9iJYPEAIQDA",
        "CgkI99L9iJYPEAIQDQ",
        "CgkI99L9iJYPEAIQEw"
    };


        for (int i = 0; i < dataManager.listDataProgress.dataProgresses.Count; i++)
        {
            float currentProgress = (float)dataManager.listDataProgress.dataProgresses[i].currentValue /
                dataManager.listDataQuest.questData[i].valueTarget;

            UnlockAchievement(achievementIDs[i], currentProgress);
            Debug.Log($"progress{i}: {currentProgress}");
        }
    }
}
