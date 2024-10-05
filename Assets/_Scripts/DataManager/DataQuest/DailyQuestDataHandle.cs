using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DailyQuestDataHandle : MonoBehaviour
{
    public DailyQuestData dailyQuestData;
    public DataProgress dataProgress;
    public Image iconUI;
    public Text titleUI;
    public Text descriptionUI;
    public Text processUI;
    public Image scrollbarUI;
    public Text valueBarUI;


    public void SetData(DailyQuestData dailyQuestData, DataProgress dataProgress)
    {
        this.dailyQuestData = dailyQuestData;
        this.dataProgress = dataProgress;
        UIQuest();
    }

    public void SetDataProgress(DataProgress dataProgress)
    {
        this.dataProgress = dataProgress;
        UIQuest();
    }

    public void UIQuest()
    {
        SetProgress();
        this.iconUI.sprite = dailyQuestData.icon;
        this.titleUI.text = dailyQuestData.title;
        this.descriptionUI.text = dailyQuestData.description;
        this.valueBarUI.text = dataProgress.currentValue.ToString() + " / " + dailyQuestData.valueTarget.ToString();
        this.scrollbarUI.fillAmount = (float)dataProgress.currentValue / (float)dailyQuestData.valueTarget;
    }

    public void SetProgress()
    {
        if (dataProgress.currentValue < dailyQuestData.valueTarget)
        {
            this.processUI.text = "Process: Fail";
        }
        else
        {
            this.processUI.text = "Process: Complete";
        }
    }
}
