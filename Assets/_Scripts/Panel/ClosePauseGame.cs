using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosePauseGame : MonoBehaviour
{
    public Animator animatorPauseInGame;
    public GameObject pauseInGame;

    public Animator animatorButtonPauseInGame;
    public GameObject buttonPauseInGame;

    void Start()
    {
        animatorPauseInGame.updateMode = AnimatorUpdateMode.UnscaledTime;
        animatorButtonPauseInGame.updateMode = AnimatorUpdateMode.UnscaledTime;
    }

    public void PauseGame()
    {
        animatorPauseInGame.SetBool("Pause", true);
    }

    public void ResumeGame()
    {
        StartCoroutine(WaitClosePanel());
    }

    IEnumerator WaitClosePanel()
    {
        animatorPauseInGame.SetBool("Pause", false);
        yield return new WaitForSeconds(0.4f);
        pauseInGame.gameObject.SetActive(false);
    }

    public void ButtonPauseGame()
    {
        StartCoroutine(WaitButtonPauseGame());
    }

    public void ButtonResumeGame()
    {
        buttonPauseInGame.gameObject.SetActive(true);
        animatorButtonPauseInGame.SetBool("Pause", false);
    }

    IEnumerator WaitButtonPauseGame()
    {
        animatorButtonPauseInGame.SetBool("Pause", true);
        yield return new WaitForSeconds(0.4f);
        buttonPauseInGame.gameObject.SetActive(false);
    }
}
