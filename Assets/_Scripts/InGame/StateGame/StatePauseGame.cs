using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatePauseGame : MonoBehaviour
{
    public DataManager dataManager;
    public GameObject uiGameControl;
    public void PauseGame()
    {
        Time.timeScale = 0;
        uiGameControl.SetActive(false);
    }

    public void ResumeGame()
    {
        if(dataManager.dataBase.indexGameMode == 0)
        {
            Time.timeScale = 1;
        }
        else if (dataManager.dataBase.indexGameMode == 1)
        {
            Time.timeScale = 1.3f;
        }
        uiGameControl.SetActive(true);
    }
}
