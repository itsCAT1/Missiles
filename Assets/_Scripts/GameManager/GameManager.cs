using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int bonusCoin;
    public static int starPoint;
    int totalPoint;
    public Text uiBonusCoin;
    public Text uiStarPointInGame;
    public Text uiStarPointEndGame;
    public Text uiTimePoint;
    public Text uiTotalPoint;
    public Text uiYourScore;

    public GameObject panelEndGame;
    public PlaneManager planeManager;
    public StateStartGame stateStartGame;
    public TimeCountBegin timeCountBegin;

    private void Update()
    {
        if (panelEndGame)
        {
            UpdateUIValue();
        }
    }

    public void UpdateUIValue()
    {
        uiBonusCoin.text = bonusCoin.ToString();
        uiStarPointInGame.text = starPoint.ToString();
        uiStarPointEndGame.text = "+" + starPoint * 10;
        uiTimePoint.text = "+" + timeCountBegin.seconds.ToString();
        totalPoint = starPoint * 10 + timeCountBegin.seconds + bonusCoin;
        uiTotalPoint.text = totalPoint.ToString();
        uiYourScore.text = totalPoint.ToString();
    }


    public void PressButtonDouble()
    {
        totalPoint *= 2;
        //Update();
    }
}
