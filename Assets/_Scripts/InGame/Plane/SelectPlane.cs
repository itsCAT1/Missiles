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
    public List<GameObject> audioSources;

    public GameObject leftArrow;
    public GameObject rightArrow;

    public CinemachineVirtualCamera virtualCamera;

    public ListSkillBase listSkillBase;
    public SelectSkill selectSkill;
    public ListSkillOwned listSkillOwned;
    public GameObject modeUI;


    public void Start()
    {
        UpdateArrow();
        LoadSkill();
        LoadAudio();
    }

    public void SelectLeftArrow()
    {
        if (dataManager.dataBase.indexPlane > 0)
        {
            virtualCamera.Follow = planeManager.planes[dataManager.dataBase.indexPlane - 1].transform;
            dataManager.dataBase.indexPlane--;
            UpdateArrow();
            LoadSkill();
            LoadAudio();
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
            LoadAudio();
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

    public void LoadAudio()
    {
        for (int i = 0; i < planeManager.planes.Count; i++)
        {
            audioSources[i].SetActive(i == dataManager.dataBase.indexPlane);
        }
    }

    public void LoadSkill()
    {
        int indexPlane = dataManager.dataBase.indexPlane;
        Debug.Log(listSkillOwned.listSkillOwned[indexPlane]);
        string itemKey = "skillOwned" + indexPlane;
        if (!selectSkill.CheckItem(itemKey))
        {
            selectSkill.uiSkill[indexPlane].SetActive(false);

        }
    }
}
