using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatePauseGame : MonoBehaviour
{
    public SelectGameMode selectGameMode;
    public GameObject uiGameControl;
    public void PauseGame()
    {
        Time.timeScale = 0;
        uiGameControl.SetActive(false);
    }

    public void ResumeGame()
    {
        if(selectGameMode.gameMode == 0)
        {
            Time.timeScale = 1;
        }
        else if (selectGameMode.gameMode == 1)
        {
            Time.timeScale = 1.4f;
        }
        uiGameControl.SetActive(true);
    }
}
