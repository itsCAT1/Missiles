using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlaneManager : MonoBehaviour
{
    public List<GameObject> planes;
    public DataPlaneManager dataPlaneManager;
    public CinemachineVirtualCamera virtualCamera;
    public GameObject leftArrow;
    public GameObject rightArrow;
    public List<GameObject> skillPlane;
    void Start()
    {
        //ShowCurrentPlane();
        virtualCamera.Follow = planes[dataPlaneManager.dataPlane.indexPlane].transform;
    }

    private void Update()
    {
        if(dataPlaneManager.dataPlane.indexPlane == 0)
        {
            leftArrow.SetActive(false);
        }
        else leftArrow.SetActive(true);

        if (dataPlaneManager.dataPlane.indexPlane == planes.Count - 1)
        {
            rightArrow.SetActive(false);
        }
        else rightArrow.SetActive(true);
        ShowSkillPlane();
    }

    public void SelectLeftArrow()
    {
        if (dataPlaneManager.dataPlane.indexPlane > 0)
        {
            virtualCamera.Follow = planes[dataPlaneManager.dataPlane.indexPlane - 1].transform;
            dataPlaneManager.dataPlane.indexPlane--;
        }
    }

    public void SelectRightArrow()
    {
        if (dataPlaneManager.dataPlane.indexPlane < planes.Count - 1)
        {
            virtualCamera.Follow = planes[dataPlaneManager.dataPlane.indexPlane + 1].transform;
            dataPlaneManager.dataPlane.indexPlane++;
        }
    }

    public void ShowSkillPlane()
    {
        for (int i = 0; i < planes.Count; i++)
        {
            skillPlane[i].SetActive(i == dataPlaneManager.dataPlane.indexPlane);
        }
    }
}