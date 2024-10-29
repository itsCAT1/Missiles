using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosePanelOptionsEndGame : MonoBehaviour
{
    public Animator animatorPanelOptionsEndGame;
    public GameObject panelOptionsEndGame;

    public void OpenPanel()
    {
        animatorPanelOptionsEndGame.SetBool("Open", true);
    }

    public void ClosePanel()
    {
        StartCoroutine(WaitClosePanel());
    }

    IEnumerator WaitClosePanel()
    {
        animatorPanelOptionsEndGame.SetBool("Open", false);
        yield return new WaitForSecondsRealtime(0.4f);
        panelOptionsEndGame.gameObject.SetActive(false);
    }
}
