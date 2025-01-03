﻿using System.Collections;
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

        for (int i = 0; i < planeManager.planes.Count; i++)
        {
            planeManager.planes[i].SetActive(i == dataManager.dataBase.indexPlane);
        }

        if (dataManager.dataBase.indexGameMode == 0)
        {
            Time.timeScale = 1f;
        }
        else if (dataManager.dataBase.indexGameMode == 1)
        {
            Time.timeScale = 1.3f;
        }
    }

    IEnumerator WaitPlaneRotate()
    {
        var plane = planeManager.planes[dataManager.dataBase.indexPlane].GetComponent<PlaneController>();
        float duration = 1f; 
        float timeCount = 0f;
        Quaternion rotate = plane.transform.rotation; 

        while (timeCount < duration)
        {
            float time = timeCount / duration;
            float angle = Mathf.LerpAngle(rotate.eulerAngles.z, 180, time);
            plane.transform.rotation = Quaternion.Euler(0, 0, angle); 
            timeCount += Time.deltaTime; 
            yield return null; 
        }
        plane.transform.rotation = Quaternion.Euler(0, 0, 180);
        isStartGame = true;
        timeCountBegin.StartTimeGame();
    }

    IEnumerator WaitClosePanel()
    {
        animatorPanelMenu.SetBool("Open", false);
        yield return new WaitForSecondsRealtime(0.4f);
        panelMenu.SetActive(false);
    }
}
