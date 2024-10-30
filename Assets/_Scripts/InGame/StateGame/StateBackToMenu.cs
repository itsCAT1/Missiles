using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StateBackToMenu : MonoBehaviour
{
    public DataManager dataManager;

    public void BackToHome()
    {
        dataManager.SaveDataBase();
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
