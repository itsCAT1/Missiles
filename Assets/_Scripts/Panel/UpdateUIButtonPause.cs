using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateUIButtonPause : MonoBehaviour
{
    public GameObject buttonPauseInGame;
    public Animator animator;


    public void OnEnable()
    {
        StartCoroutine(WaitButtonPauseGame());
    }

    IEnumerator WaitButtonPauseGame()
    {
        animator.SetBool("Pause", true);
        yield return new WaitForSecondsRealtime(0.4f);
        buttonPauseInGame.gameObject.SetActive(false);
    }
}
