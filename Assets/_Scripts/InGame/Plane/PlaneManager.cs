using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlaneManager : MonoBehaviour
{
    public List<GameObject> planes;
    public List<GameObject> audioSources;
    public DataManager dataManager;
    public CinemachineVirtualCamera virtualCamera;
    
    void Start()
    {
        virtualCamera.Follow = planes[dataManager.dataBase.indexPlane].transform;
    }

    private void Update()
    {
        for (int i = 0; i < planes.Count; i++)
        {
            audioSources[i].SetActive(i == dataManager.dataBase.indexPlane);
        }
    }
}