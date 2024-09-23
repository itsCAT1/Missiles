using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClosePanelShop : MonoBehaviour
{
    public Animator animatorPanelShop;
    public GameObject panelShop;

    public void OpenPanel()
    {
        animatorPanelShop.SetTrigger("Open");
    }

    public void ClosePanel()
    {
        StartCoroutine(WaitClosePanel());
    }

    IEnumerator WaitClosePanel()
    {
        animatorPanelShop.SetTrigger("Close");
        yield return new WaitForSeconds(1f);
        panelShop.gameObject.SetActive(false);
    }
}
