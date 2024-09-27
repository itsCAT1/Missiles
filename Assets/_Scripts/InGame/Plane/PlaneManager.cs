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
    public GameObject leftArrow;
    public GameObject rightArrow;
    public List<GameObject> skillPlane;
    void Start()
    {
        //ShowCurrentPlane();
        
    }

    private void Update()
    {
        if(currentPlaneIndex == 0)
        {
            leftArrow.SetActive(false);
        }
        else leftArrow.SetActive(true);

        if (currentPlaneIndex == planes.Count - 1)
        {
            rightArrow.SetActive(false);
        }
        else rightArrow.SetActive(true);
        ShowSkillPlane();
    }

    public void SelectLeftArrow()
    {
        if (currentPlaneIndex > 0)
        {
            virtualCamera.Follow = planes[currentPlaneIndex - 1].transform;
            currentPlaneIndex--;
        }
    }

    public void SelectRightArrow()
    {
        if (currentPlaneIndex < planes.Count - 1)
        {
            virtualCamera.Follow = planes[currentPlaneIndex + 1].transform;
            currentPlaneIndex++;
        }
    }

    public void ShowSkillPlane()
    {
        for (int i = 0; i < planes.Count; i++)
        {
            skillPlane[i].SetActive(i == currentPlaneIndex);
        }
    }
}