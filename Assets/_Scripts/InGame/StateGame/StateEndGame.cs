using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class StateEndGame : MonoBehaviour
{
    public PlaneManager planeManager;
    public DataPlaneManager dataPlaneManager;
    Transform plane;

    public GameObject upBG;
    public GameObject endGamePanel;
    public GameObject uiGameControl;
    private void Update()
    {
        if (!planeManager.planes[dataPlaneManager.dataPlane.indexPlane].gameObject.activeSelf)
        {
            endGamePanel.SetActive(true);
            uiGameControl.SetActive(false);
        }
    }
}
