﻿using GooglePlayGames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

string[] achievementIDs = {
    "CgkI99L9iJYPEAIQBA",
    "CgkI99L9iJYPEAIQBQ",
    "CgkI99L9iJYPEAIQBg",
    "CgkI99L9iJYPEAIQBw",
    "CgkI99L9iJYPEAIQCA",
    "CgkI99L9iJYPEAIQCQ",
    "CgkI99L9iJYPEAIQCg",
    "CgkI99L9iJYPEAIQCw",
    "CgkI99L9iJYPEAIQDA",
    "CgkI99L9iJYPEAIQDQ"
};

public class AchievementHandler : MonoBehaviour
{
    public DataManager dataManager;

    public void UpdateAchievementProgress(string achievementID, float progressPercentage)
    {
        // Báo cáo phần trăm hoàn thành của achievement
        Social.ReportProgress(achievementID, progressPercentage * 100, (bool success) =>
        {
            if (success)
            {
                Debug.Log("Progress của thành tích đã được cập nhật thành công!");
            }
            else
            {
                Debug.Log("Cập nhật progress thất bại.");
            }
        });
    }

    public void ShowAchievementsUI()
    {
        PlayGamesPlatform.Instance.ShowAchievementsUI();
    }

    public void ShowProgressAchievement()
    {
        string[] achievementIDs = {
        "CgkI99L9iJYPEAIQBA",
        "CgkI99L9iJYPEAIQBQ",
        "CgkI99L9iJYPEAIQBg",
        "CgkI99L9iJYPEAIQBw",
        "CgkI99L9iJYPEAIQCA",
        "CgkI99L9iJYPEAIQCQ",
        "CgkI99L9iJYPEAIQCg",
        "CgkI99L9iJYPEAIQCw",
        "CgkI99L9iJYPEAIQDA",
        "CgkI99L9iJYPEAIQDQ"
    };


        for (int i = 0; i < dataManager.listDataProgress.dataProgresses.Count; i++)
        {
            float currentProgress = (float)dataManager.listDataProgress.dataProgresses[i].currentValue /
                dataManager.listDataQuest.questData[i].valueTarget;

            UpdateAchievementProgress(achievementIDs[i], currentProgress);
            Debug.Log($"progress{i}: {currentProgress}");
        }
    }
}