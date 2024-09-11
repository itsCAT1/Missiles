using System.Collections;
using System.Collections.Generic;
using TreeEditor;
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
        ShowCurrentPlane();
        mainCamera = Camera.main;
        cameraController = mainCamera.GetComponent<CameraController>();
    }

    public void SelectLeftArrow()
    {
        if (currentPlaneIndex > 0)
        {
            currentPlaneIndex--;
            ShowCurrentPlane();
            cameraController.isCameraControlling = true; // Kích hoạt điều khiển thủ công
            mainCamera.transform.Translate(Vector3.left * moveDistance);
        }
    }

    public void SelectRightArrow()
    {
        if (currentPlaneIndex < planes.Count - 1)
        {
            currentPlaneIndex++;
            ShowCurrentPlane();
            cameraController.isCameraControlling = true; // Kích hoạt điều khiển thủ công
            mainCamera.transform.Translate(Vector3.right * moveDistance);
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