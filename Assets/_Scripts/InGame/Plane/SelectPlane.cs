using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class SelectPlane : MonoBehaviour
{
    public DataPlaneManager dataPlaneManager;
    public PlaneManager planeManager;

    public GameObject leftArrow;
    public GameObject rightArrow;
    public List<GameObject> skillPlane;
    public CinemachineVirtualCamera virtualCamera;
    public int a;

    private void Update()
    {
        a = dataPlaneManager.dataPlane.indexPlane;
        if (dataPlaneManager.dataPlane.indexPlane == 0)
        {
            leftArrow.SetActive(false);
        }
        else leftArrow.SetActive(true);

        if (dataPlaneManager.dataPlane.indexPlane == planeManager.planes.Count - 1)
        {
            rightArrow.SetActive(false);
        }
        else rightArrow.SetActive(true);
        //ShowSkillPlane();
    }

    public void SelectLeftArrow()
    {
        if (dataPlaneManager.dataPlane.indexPlane > 0)
        {
            virtualCamera.Follow = planeManager.planes[dataPlaneManager.dataPlane.indexPlane - 1].transform;
            dataPlaneManager.dataPlane.indexPlane--;
        }
    }

    public void SelectRightArrow()
    {
        if (dataPlaneManager.dataPlane.indexPlane < planeManager.planes.Count - 1)
        {
            virtualCamera.Follow = planeManager.planes[dataPlaneManager.dataPlane.indexPlane + 1].transform;
            dataPlaneManager.dataPlane.indexPlane++;
        }
    }

    public void ShowSkillPlane()
    {
        for (int i = 0; i < planeManager.planes.Count; i++)
        {
            skillPlane[i].SetActive(i == dataPlaneManager.dataPlane.indexPlane);
        }
    }
}
