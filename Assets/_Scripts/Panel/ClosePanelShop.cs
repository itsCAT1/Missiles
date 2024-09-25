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
        animatorPanelShop.SetBool("Open", true);
    }

    public void ClosePanel()
    {
        StartCoroutine(WaitClosePanel());
    }

    IEnumerator WaitClosePanel()
    {
        animatorPanelShop.SetBool("Open", false);
        yield return new WaitForSeconds(0.4f);
        panelShop.gameObject.SetActive(false);
    }
}
