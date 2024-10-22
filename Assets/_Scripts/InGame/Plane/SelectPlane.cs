using Cinemachine;
using GooglePlayGames.BasicApi;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Reflection;
using UnityEngine;

public class SelectPlane : MonoBehaviour
{
    public DataManager dataManager;
    public PlaneManager planeManager;

    public GameObject leftArrow;
    public GameObject rightArrow;

    public CinemachineVirtualCamera virtualCamera;

    public SkillManager selectSkill;
    
    public void Start()
    {
        UpdateArrow();
    }

    public void SelectLeftArrow()
    {
        if (dataManager.dataBase.indexPlane > 0)
        {
            virtualCamera.Follow = planeManager.planes[dataManager.dataBase.indexPlane - 1].transform;
            dataManager.dataBase.indexPlane--;
            UpdateArrow();
            selectSkill.LoadSkill();
            planeManager.LoadAudio();
        }
    }

    public void SelectRightArrow()
    {
        
        if (dataManager.dataBase.indexPlane < planeManager.planes.Count - 1)
        {
            virtualCamera.Follow = planeManager.planes[dataManager.dataBase.indexPlane + 1].transform;
            dataManager.dataBase.indexPlane++;
            UpdateArrow();
            selectSkill.LoadSkill();
            planeManager.LoadAudio();
        }
    }
    private void UpdateArrow()
    {
        if (dataManager.dataBase.indexPlane == 0)
        {
            leftArrow.SetActive(false);
        }
        else leftArrow.SetActive(true);

        if (dataManager.dataBase.indexPlane == planeManager.planes.Count - 1)
        {
            rightArrow.SetActive(false);
        }
        else rightArrow.SetActive(true);
    }

    
}
