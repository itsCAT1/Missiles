using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlaneManager : MonoBehaviour
{
    public DataManager dataManager;
    public CinemachineVirtualCamera virtualCamera;

    public List<GameObject> planes;
    public List<GameObject> audioSources;



    void Start()
    {
        virtualCamera.Follow = planes[dataManager.dataBase.indexPlane].transform;
        LoadAudio();
    }

    public void StartGame()
    {
        virtualCamera.GetCinemachineComponent<CinemachineTransposer>().m_XDamping = 0;
    }

    public void LoadAudio()
    {
        for (int i = 0; i < planes.Count; i++)
        {
            audioSources[i].SetActive(i == dataManager.dataBase.indexPlane);
        }
    }
}