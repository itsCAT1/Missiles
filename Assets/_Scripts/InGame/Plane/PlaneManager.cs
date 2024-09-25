using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlaneManager : MonoBehaviour
{
    public List<GameObject> planes;
    public int currentPlaneIndex = 0;
    public float moveDistance = 3.5f;
    private Camera mainCamera;
    private CameraController cameraController;
    
    void Start()
    {
        //ShowCurrentPlane();
        cameraController = mainCamera.GetComponent<CameraController>();
    }

    public void SelectLeftArrow()
    {
        if (currentPlaneIndex > 0)
        {
            
            //ShowCurrentPlane();
            cameraController.isCameraControlling = true;
            var posCamera = mainCamera.transform.position;
            posCamera = Vector2.Lerp(planes[currentPlaneIndex].transform.position,
                planes[currentPlaneIndex - 1].transform.position, 1);
            posCamera.z = -10;
            mainCamera.transform.position = posCamera;
            currentPlaneIndex--;
        }
    }

    public void SelectRightArrow()
    {
        if (currentPlaneIndex < planes.Count - 1)
        {
            
            //ShowCurrentPlane();
            cameraController.isCameraControlling = true;
            var posCamera = mainCamera.transform.position;
            posCamera = Vector2.Lerp(planes[currentPlaneIndex].transform.position,
                planes[currentPlaneIndex + 1].transform.position, 1);
            posCamera.z = -10;
            mainCamera.transform.position = posCamera;
            currentPlaneIndex++;
        }
    }

    public void ShowCurrentPlane()
    {
        for (int i = 0; i < planes.Count; i++)
        {
            if (planes[i] != null)
            {
                planes[i].SetActive(i == currentPlaneIndex);
            }
        }
    }
}