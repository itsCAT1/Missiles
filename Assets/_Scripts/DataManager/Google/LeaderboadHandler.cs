using GooglePlayGames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboadHandler : MonoBehaviour
{
    public DataManager dataManager;
    public void ReportScoreToLeaderboard(int score, string leaderboardID)
    {
        Social.ReportScore(score, leaderboardID, (bool success) =>
        {
            if (success)
            {
                Debug.Log("Update score success");
            }
            else
            {
                Debug.Log("Update score fail");
            }
        });
    }

    public void ShowLeaderboardUI()
    {
        PlayGamesPlatform.Instance.ShowLeaderboardUI();
    }

    public void ShowLeaderboardWithMode()
    {
        if(dataManager.dataBase.indexGameMode == 0)
        {
            PlayGamesPlatform.Instance.ShowLeaderboardUI("CgkI99L9iJYPEAIQAg");
        }
        else
        {
            PlayGamesPlatform.Instance.ShowLeaderboardUI("CgkI99L9iJYPEAIQAw");
        }
    }
}
