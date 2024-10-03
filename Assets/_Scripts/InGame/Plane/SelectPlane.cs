using Cinemachine;
using GooglePlayGames.BasicApi;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class SelectPlane : MonoBehaviour
{
    public DataManager dataManager;
    public PlaneManager planeManager;

    public GameObject leftArrow;
    public GameObject rightArrow;
    public CinemachineVirtualCamera virtualCamera;
    public ListSkillBase listSkillBase;
    public SelectSkill selectSkill;

    public void Start()
    {
        UpdateArrow();
        LoadSkill();
        //UpdateSkill();
    }

    public void SelectLeftArrow()
    {
        if (dataManager.dataBase.indexPlane > 0)
        {
            virtualCamera.Follow = planeManager.planes[dataManager.dataBase.indexPlane - 1].transform;
            dataManager.dataBase.indexPlane--;
            UpdateArrow();
            LoadSkill();
            //UpdateSkill();
        }
    }

    public void SelectRightArrow()
    {
        
        if (dataManager.dataBase.indexPlane < planeManager.planes.Count - 1)
        {
            virtualCamera.Follow = planeManager.planes[dataManager.dataBase.indexPlane + 1].transform;
            dataManager.dataBase.indexPlane++;
            UpdateArrow();
            LoadSkill();
            //UpdateSkill();
            
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

    public void LoadSkill()
    {
        for (int i = 0; i < planeManager.planes.Count; i++)
        {
            selectSkill.uiGameMode[i].SetActive(i == dataManager.dataBase.indexPlane);
        }
    }


    public void UpdateSkill()
    {
        for (int i = 0; i < listSkillBase.listSkillBase.Count; i++)
        {
            string itemKey = "skillOwned" + i;

            if (selectSkill.CheckItem(itemKey))
            {
                selectSkill.uiGameMode[i].SetActive(false);
            }
            else selectSkill.uiGameMode[i].SetActive(true);
        }
    }
}
