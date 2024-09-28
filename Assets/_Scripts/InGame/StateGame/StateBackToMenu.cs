using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StateBackToMenu : MonoBehaviour
{
    public DataGameplayManager dataGameplayManager;

    public void BackToHome()
    {
        SceneManager.LoadScene(0);
        dataGameplayManager.SaveDataGameplay();
        dataGameplayManager.LoadDataGameplay();
        Time.timeScale = 1;
    }
}
