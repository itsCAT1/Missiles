using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatePauseGame : MonoBehaviour
{
    public DataGameplayManager dataGameplayManager;
    public GameObject uiGameControl;
    public void PauseGame()
    {
        Time.timeScale = 0;
        uiGameControl.SetActive(false);
    }

    public void ResumeGame()
    {
        if(dataGameplayManager.dataGameplay.indexGameMode == 0)
        {
            Time.timeScale = 1;
        }
        else if (dataGameplayManager.dataGameplay.indexGameMode == 1)
        {
            Time.timeScale = 1.4f;
        }
        uiGameControl.SetActive(true);
    }
}
