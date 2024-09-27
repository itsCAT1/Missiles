using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class StateEndGame : MonoBehaviour
{
    public PlaneManager planeManager;
    Transform plane;

    public GameObject upBG;
    public GameObject endGamePanel;
    public GameObject uiGameControl;
    void Start()
    {
        plane = planeManager.planes[planeManager.currentPlaneIndex].GetComponent<Transform>();
    }
    private void Update()
    {
        if (!plane.gameObject.activeSelf)
        {
            endGamePanel.SetActive(true);
            uiGameControl.SetActive(false);
        }
        else endGamePanel.SetActive(false);
    }
}
