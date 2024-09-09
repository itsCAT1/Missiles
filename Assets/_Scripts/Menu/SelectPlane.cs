using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPlane : MonoBehaviour
{
    private Camera mainCamera;
    public float moveDistance = 3.5f;

    private CameraController cameraController; // Tham chiếu đến CameraController để kiểm soát điều khiển

    private void Start()
    {
        mainCamera = Camera.main;
        cameraController = mainCamera.GetComponent<CameraController>(); // Tìm CameraController trên camera chính
    }

    public void SelectLeftArrow()
    {
        Debug.Log("left");
        cameraController.isCameraControlling = true; // Kích hoạt điều khiển thủ công
        Vector3 pos = mainCamera.transform.localPosition + Vector3.left * moveDistance;
        mainCamera.transform.localPosition = pos;
    }

    public void SelectRightArrow()
    {
        Debug.Log("right");
        cameraController.isCameraControlling = true; // Kích hoạt điều khiển thủ công
        Vector3 pos = mainCamera.transform.localPosition + Vector3.right * moveDistance;
        mainCamera.transform.localPosition = pos;
    }
}
