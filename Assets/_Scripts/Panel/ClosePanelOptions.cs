using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClosePanelOptions : MonoBehaviour
{
    public Animator animatorPanelOptions;
    public GameObject panelOptions;

    public void OpenPanel()
    {
        animatorPanelOptions.SetTrigger("Open");
    }

    public void ClosePanel()
    {
        StartCoroutine(WaitClosePanel());
    }

    IEnumerator WaitClosePanel()
    {
        animatorPanelOptions.SetTrigger("Close");
        yield return new WaitForSeconds(1f);
        panelOptions.gameObject.SetActive(false);
    }
}
