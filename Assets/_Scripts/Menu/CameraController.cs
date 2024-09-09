using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public Vector3 offSet;
    private Camera mainCamera;
    public bool isCameraControlling = false; 

    private void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (!isCameraControlling)
        {
            CameraFollowPlayer();
        }
    }

    void CameraFollowPlayer()
    {
        Vector3 pos = player.position + offSet;
        pos.z = mainCamera.transform.localPosition.z;

        mainCamera.transform.localPosition = pos;
    }

    // Gọi phương thức này khi bạn muốn camera quay lại theo dõi người chơi
    public void ResetCameraControl()
    {
        isCameraControlling = false;
    }
}
