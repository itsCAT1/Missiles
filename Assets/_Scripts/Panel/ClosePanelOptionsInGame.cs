using System.Collections;
using UnityEngine;

public class ClosePanelOptionsInGame : MonoBehaviour
{
    public Animator animatorPanelOptionsInGame;
    public GameObject panelOptionsInGame;

    void Start()
    {
        animatorPanelOptionsInGame.updateMode = AnimatorUpdateMode.UnscaledTime;
    }

    public void OpenPanel()
    {
        animatorPanelOptionsInGame.SetBool("Open", true);
    }

    public void ClosePanel()
    {
        StartCoroutine(WaitClosePanel());
    }

    IEnumerator WaitClosePanel()
    {
        animatorPanelOptionsInGame.SetBool("Open", false);
        yield return new WaitForSeconds(0.4f);
        panelOptionsInGame.gameObject.SetActive(false);
    }
}
