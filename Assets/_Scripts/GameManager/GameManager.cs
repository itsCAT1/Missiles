using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int bonusCoin;
    public static int starPoint;
    public int totalScore;
    public Text uiBonusCoin;
    public Text uiStarPointInGame;
    public Text uiStarPointEndGame;
    public Text uiTimePoint;
    public Text uiTotalPoint;
    public Text uiYourScore;

    public GameObject panelEndGame;
    public PlaneManager planeManager;
    public TimeCountBegin timeCountBegin;
    public DataManager dataManager;

    public GameObject uiScore;
    public GameObject uiBestScore;

    public bool isScoreUpdated = false;
    public bool isDoubleScore = false;

    private void Update()
    {
        uiStarPointInGame.text = starPoint.ToString();
        
        if (!planeManager.planes[dataManager.data.indexPlane].gameObject.activeSelf && !isScoreUpdated)
        {
            UpdateUIValue();
            isScoreUpdated = true;
        }
    }

    public void SetValue()
    {
        totalScore = starPoint * 10 + timeCountBegin.timeCount + bonusCoin;
        
        if (dataManager.data.indexGameMode == 0)
        {
            if (totalScore > dataManager.data.bestScoreNormalMode)
            {
                dataManager.data.bestScoreNormalMode = totalScore;
                uiScore.gameObject.SetActive(false);
                uiBestScore.gameObject.SetActive(true);
            }
            else
            {
                uiScore.gameObject.SetActive(true);
                uiBestScore.gameObject.SetActive(false);
            }
        }
        else if (dataManager.data.indexGameMode == 1)
        {
            if (totalScore > dataManager.data.bestScoreFastMode)
            {
                Debug.Log("BestScoreFast");
                dataManager.data.bestScoreFastMode = totalScore;
                uiScore.gameObject.SetActive(false);
                uiBestScore.gameObject.SetActive(true);
            }
            else
            {
                uiScore.gameObject.SetActive(true);
                uiBestScore.gameObject.SetActive(false);
            }
        }

        dataManager.data.coin += totalScore;
        dataManager.SaveData();
    }

    public void UpdateUIValue()
    {
        SetValue();  

        uiBonusCoin.text = bonusCoin.ToString();
        uiStarPointEndGame.text = "+" + starPoint * 10;
        uiTimePoint.text = "+" + timeCountBegin.timeCount.ToString();
        uiTotalPoint.text = totalScore.ToString();
        uiYourScore.text = totalScore.ToString();
    }


    public void PressButtonDouble()
    {
        totalScore *= 2;
        uiTotalPoint.text = totalScore.ToString();
        dataManager.data.coin += totalScore/2;
    }
}
