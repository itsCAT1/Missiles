using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveCurrentPlane : MonoBehaviour
{
    public PlaneManager planeManager;
    public DataManager dataManager;
    
    void Start()
    {
        ShowPlane();
    }

    public void ShowPlane()
    {
        for (int i = 0; i < planeManager.planes.Count; i++)
        {
            planeManager.planes[i].SetActive(i == dataManager.data.indexPlane);
        }
    }
}
