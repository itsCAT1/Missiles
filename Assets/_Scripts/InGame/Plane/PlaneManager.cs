using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlaneManager : MonoBehaviour
{
    public List<GameObject> planes;
    public int currentPlaneIndex = 0;
    public CinemachineVirtualCamera virtualCamera;

    void Start()
    {
        //ShowCurrentPlane();
        
    }

    public void SelectLeftArrow()
    {
        if (currentPlaneIndex > 0)
        {

            //ShowCurrentPlane();
            virtualCamera.Follow = planes[currentPlaneIndex - 1].transform;
            currentPlaneIndex--;
        }
    }

    public void SelectRightArrow()
    {
        if (currentPlaneIndex < planes.Count - 1)
        {

            //ShowCurrentPlane();
            virtualCamera.Follow = planes[currentPlaneIndex + 1].transform;
            currentPlaneIndex++;
        }
    }

    public void ShowCurrentPlane()
    {
        for (int i = 0; i < planes.Count; i++)
        {
            if (planes[i] != null)
            {
                planes[i].SetActive(i == currentPlaneIndex);
            }
        }
    }
}