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

    
}