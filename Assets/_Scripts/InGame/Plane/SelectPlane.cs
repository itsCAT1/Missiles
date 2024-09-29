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

    private void Update()
    {
        if (dataManager.data.indexPlane == 0)
        {
            leftArrow.SetActive(false);
        }
        else leftArrow.SetActive(true);

        if (dataManager.data.indexPlane == planeManager.planes.Count - 1)
        {
            rightArrow.SetActive(false);
        }
        else rightArrow.SetActive(true);
        ShowSkillPlane();
    }

    public void SelectLeftArrow()
    {
        if (dataManager.data.indexPlane > 0)
        {
            virtualCamera.Follow = planeManager.planes[dataManager.data.indexPlane - 1].transform;
            dataManager.data.indexPlane--;
        }
    }

    public void SelectRightArrow()
    {
        if (dataManager.data.indexPlane < planeManager.planes.Count - 1)
        {
            virtualCamera.Follow = planeManager.planes[dataManager.data.indexPlane + 1].transform;
            dataManager.data.indexPlane++;
        }
    }

    public void ShowSkillPlane()
    {
        for (int i = 0; i < planeManager.planes.Count; i++)
        {
            skillPlane[i].SetActive(i == dataManager.data.indexPlane);
        }
    }
}
