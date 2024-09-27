using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text timeCount;
    public static int bonusCoin;
    public static int starPoint;
    int minutes;
    int seconds;
    int totalPoint;
    public Text uiBonusCoin;
    public Text uiStarPointInGame;
    public Text uiStarPointEndGame;
    public Text uiTimePoint;
    public Text uiTotalPoint;
    public Text uiYourScore;

    public GameObject panelEndGame;

    void Start()
    {
        StartCoroutine(StartTimeCount());
    }

    private void OnEnable()
    {
        UpdateUIValue();
    }

    public void UpdateUIValue()
    {
        uiBonusCoin.text = bonusCoin.ToString();
        uiStarPointInGame.text = starPoint.ToString();
        uiStarPointEndGame.text = "+" + starPoint * 10;
        uiTimePoint.text = "+" + seconds.ToString();
        totalPoint = starPoint * 10 + seconds + bonusCoin;
        uiTotalPoint.text = totalPoint.ToString();
        uiYourScore.text = totalPoint.ToString();
    }

    IEnumerator StartTimeCount()
    {
        while (true)
        {
            minutes = Mathf.FloorToInt(Time.time / 60);
            seconds = Mathf.FloorToInt(Time.time % 60);

            timeCount.text = string.Format("{0}:{1:00}", minutes, seconds);

            yield return new WaitForSeconds(1f);
        }
    }

    public void PressButtonDouble()
    {
        totalPoint *= 2;
        //Update();
    }
}
