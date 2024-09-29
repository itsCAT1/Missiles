using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class StateStartGame : MonoBehaviour
{
    public DataManager dataManager;
    public PlaneManager planeManager;
    public Animator animatorPanelMenu;
    public GameObject panelMenu;
    public bool isStartGame = false;
    public TimeCountBegin timeCountBegin;


    public void StartGame()
    {
        StartCoroutine(WaitClosePanel());
        StartCoroutine(WaitPlaneRotate());
        timeCountBegin.StartTimeGame();
        isStartGame = true;
        for (int i = 0; i < planeManager.planes.Count; i++)
        {
            planeManager.planes[i].SetActive(i == dataManager.data.indexPlane);
        }

        if (dataManager.data.indexGameMode == 0)
        {
            Time.timeScale = 1f;
        }
        else if (dataManager.data.indexGameMode == 1)
        {
            Time.timeScale = 1.4f;
        }
    }


    IEnumerator WaitPlaneRotate()
    {
        var planeTemp = planeManager.planes[dataManager.data.indexPlane].GetComponent<PlaneController>();
        planeTemp.rigid2D.angularVelocity = 185;
        yield return new WaitForSeconds(1);
        planeTemp.rigid2D.angularVelocity = 0;
    }

    IEnumerator WaitClosePanel()
    {
        animatorPanelMenu.SetBool("Open", false);
        yield return new WaitForSeconds(0.4f);
        panelMenu.SetActive(false);
    }
}
