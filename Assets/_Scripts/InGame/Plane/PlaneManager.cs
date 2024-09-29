using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlaneManager : MonoBehaviour
{
    public List<GameObject> planes;
    public DataManager dataManager;
    public CinemachineVirtualCamera virtualCamera;
    void Start()
    {
        virtualCamera.Follow = planes[dataManager.data.indexPlane].transform;
    }
}