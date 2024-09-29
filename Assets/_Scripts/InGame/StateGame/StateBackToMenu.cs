using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StateBackToMenu : MonoBehaviour
{
    public DataManager dataManager;

    public void BackToHome()
    {
        dataManager.SaveData();
        SceneManager.LoadScene(0);
        dataManager.LoadData();
        Time.timeScale = 1;
    }
}
