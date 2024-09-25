using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClosePanelOptionsMenu : MonoBehaviour
{
    public Animator animatorPanelOptionsMenu;
    public GameObject panelOptionsMenu;

    void Start()
    {
        animatorPanelOptionsMenu.updateMode = AnimatorUpdateMode.UnscaledTime;
    }

    public void OpenPanel()
    {
        animatorPanelOptionsMenu.SetBool("Open", true);
    }

    public void ClosePanel()
    {
        StartCoroutine(WaitClosePanel());
    }

    IEnumerator WaitClosePanel()
    {
        animatorPanelOptionsMenu.SetBool("Open", false);
        yield return new WaitForSeconds(0.4f);
        panelOptionsMenu.gameObject.SetActive(false);
    }
}
