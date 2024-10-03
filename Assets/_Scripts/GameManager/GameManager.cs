using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int bonusCoin = 0;
    public static int starPoint = 0;
    public static int shieldPoint = 0;
    public static int speedUpPoint = 0;

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
        
        if (!planeManager.planes[dataManager.dataBase.indexPlane].gameObject.activeSelf && !isScoreUpdated)
        {
            UpdateUIValue();
            isScoreUpdated = true;
        }
    }

    public void SetValue()
    {
        totalScore = starPoint * 10 + timeCountBegin.timeCount + bonusCoin;
        SetValueDataBase();
        
        if (dataManager.dataBase.indexGameMode == 0)
        {
            if (totalScore > dataManager.dataBase.bestScoreNormalMode)
            {
                dataManager.dataBase.bestScoreNormalMode = totalScore;
                uiScore.gameObject.SetActive(false);
                uiBestScore.gameObject.SetActive(true);
            }
            else
            {
                uiScore.gameObject.SetActive(true);
                uiBestScore.gameObject.SetActive(false);
            }
        }
        else if (dataManager.dataBase.indexGameMode == 1)
        {
            if (totalScore > dataManager.dataBase.bestScoreFastMode)
            {
                dataManager.dataBase.bestScoreFastMode = totalScore;
                uiScore.gameObject.SetActive(false);
                uiBestScore.gameObject.SetActive(true);
            }
            else
            {
                uiScore.gameObject.SetActive(true);
                uiBestScore.gameObject.SetActive(false);
            }
        }

        dataManager.UpdateValue();
        PlayerPrefs.Save();
    }

    public void SetValueDataBase()
    {
        int pointInOneGame = dataManager.dataBase.pointInOneGame;
        dataManager.dataBase.pointInOneGame = totalScore > pointInOneGame ? totalScore : pointInOneGame;
        
        int starInOneGame = dataManager.dataBase.starInOneGame;
        dataManager.dataBase.starInOneGame = starPoint > starInOneGame ? starPoint : starInOneGame;

        dataManager.dataBase.totalStar += starPoint;
        dataManager.dataBase.totalShield += shieldPoint;
        dataManager.dataBase.totalSpeedUp += speedUpPoint;
        dataManager.dataBase.totalGame += 1;
        dataManager.dataBase.coin += totalScore;
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
        dataManager.dataBase.coin += totalScore/2;
    }
}
