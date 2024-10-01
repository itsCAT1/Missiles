using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DailyQuestDataHandle : MonoBehaviour
{
    public DailyQuestData dailyQuestData;
    public DataProgress dataProgress;
    public Image icon;
    public Text title;
    public Text description;
    public Text score;
    public Text process;
    public Image scrollbar;
    public Text scoreBar;


    public void SetData(DailyQuestData dailyQuestData, DataProgress dataBase)
    {
        this.dailyQuestData = dailyQuestData;
        this.dataProgress = dataBase;
        UIQuest();
    }

    public void UIQuest()
    {
        this.icon.sprite = dailyQuestData.icon;
        this.title.text = dailyQuestData.title;
        this.description.text = dailyQuestData.description;
    }

    /*public void SetProgess()
    {
        if (questProgress.score < dailyQuestData.maxScore)
        {
            this.process.text = "Process: Fail";
        }
        else
        {
            this.process.text = "Process: Complete";
        }
    }*/
}
