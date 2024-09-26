using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planeMana : MonoBehaviour
{
    public List<GameObject> planes;
    public List<GameObject> vrCamera;
    public int index = 0;
    public CinemachineVirtualCamera virtualCamera;


    public void LeftArrow()
    {
        if(index > 0)
        {
            virtualCamera.Follow = planes[index - 1].transform;
            index--;
        }
    }

    public void RightArrow()
    {
        if (index < planes.Count - 1)
        {
            virtualCamera.Follow = planes[index + 1].transform;
            index++;
        }
    }
}
