using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StateRestartGame : MonoBehaviour
{
    public Animator animatorPanelEndGame;
    public Animator animatorPanelPauseGame;
    public DataGameplayManager dataGameplayManager;

    public void RestartGamePauseGame()
    {
        StartCoroutine(WaitAnimationPauseGame());
    }

    IEnumerator WaitAnimationPauseGame()
    {
        animatorPanelPauseGame.SetBool("Open", false);
        yield return new WaitForSecondsRealtime(0.4f);
        if (dataGameplayManager.dataGameplay.indexGameMode == 0)
        {
            Time.timeScale = 1;
        }
        else if (dataGameplayManager.dataGameplay.indexGameMode == 1)
        {
            Time.timeScale = 1.4f;
        }
        SceneManager.LoadScene(1);
    }

    public void RestartGameEndGame()
    {
        StartCoroutine(WaitAnimationEndGame());
    }

    IEnumerator WaitAnimationEndGame()
    {
        animatorPanelEndGame.SetBool("Open", false);
        yield return new WaitForSeconds(0.4f);
        SceneManager.LoadScene(1);
    }
}
