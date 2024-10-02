using Cinemachine;
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
    public List<GameObject> skillPlane;
    public CinemachineVirtualCamera virtualCamera;

    public GameObject uiMode;
    public bool isbuy;

    private void Start()
    {
        ShowSkillPlane();
    }

    private void Update()
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

    public void SelectLeftArrow()
    {
        if (dataManager.dataBase.indexPlane > 0)
        {
            virtualCamera.Follow = planeManager.planes[dataManager.dataBase.indexPlane - 1].transform;
            dataManager.dataBase.indexPlane--;
        }
        ShowSkillPlane();
    }

    public void SelectRightArrow()
    {
        if (dataManager.dataBase.indexPlane < planeManager.planes.Count - 1)
        {
            virtualCamera.Follow = planeManager.planes[dataManager.dataBase.indexPlane + 1].transform;
            dataManager.dataBase.indexPlane++;
        }
        ShowSkillPlane();
    }

    public void ShowSkillPlane()
    {
        for (int i = 0; i < planeManager.planes.Count; i++)
        {
            skillPlane[i].SetActive(i == dataManager.dataBase.indexPlane);
        }
    }

}
