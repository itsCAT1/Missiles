using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class StateEndGame : MonoBehaviour
{
    public PlaneManager planeManager;
    public DataManager dataManager;
    Transform plane;

    public GameObject upBG;
    public GameObject endGamePanel;
    public GameObject uiGameControl;

    private void Update()
    {
        if (!planeManager.planes[dataManager.dataBase.indexPlane].gameObject.activeSelf)
        {
            endGamePanel.SetActive(true);
            uiGameControl.SetActive(false);
        }
    }
}
