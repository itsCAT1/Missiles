using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateUI : MonoBehaviour
{
    public DataManager dataManager;

    public void UpdateAllUI()
    {
        foreach (var dataProgress in dataManager.listDataProgress.dataProgresses)
        {
            dataManager.uiHandlerDict[dataProgress.id].UpdateProgress(dataProgress);
        }
    }
}
