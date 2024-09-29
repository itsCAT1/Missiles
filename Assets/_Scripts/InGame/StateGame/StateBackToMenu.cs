using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StateBackToMenu : MonoBehaviour
{
    public DataGameplayManager dataGameplayManager;

    public void BackToHome()
    {
        dataGameplayManager.SaveDataGameplay();
        SceneManager.LoadScene(0);
        dataGameplayManager.LoadDataGameplay();
        Time.timeScale = 1;
    }
}
