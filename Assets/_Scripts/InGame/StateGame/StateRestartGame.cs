using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StateRestartGame : MonoBehaviour
{
    public Animator animatorPanelEndGame;
    public Animator animatorPanelPauseGame;
    public DataManager dataManager;

    public void RestartGamePauseGame()
    {
        StartCoroutine(WaitAnimationPauseGame());
    }

    IEnumerator WaitAnimationPauseGame()
    {
        animatorPanelPauseGame.SetBool("Open", false);
        yield return new WaitForSecondsRealtime(0.4f);
        if (dataManager.data.indexGameMode == 0)
        {
            Time.timeScale = 1;
        }
        else if (dataManager.data.indexGameMode == 1)
        {
            Time.timeScale = 1.4f;
        }
        dataManager.SaveData();
        SceneManager.LoadScene(1);
        dataManager.LoadData();
    }

    public void RestartGameEndGame()
    {
        StartCoroutine(WaitAnimationEndGame());
    }

    IEnumerator WaitAnimationEndGame()
    {
        animatorPanelEndGame.SetBool("Open", false);
        yield return new WaitForSeconds(0.4f);
        dataManager.SaveData();
        SceneManager.LoadScene(1);
        dataManager.LoadData();
    }
}
