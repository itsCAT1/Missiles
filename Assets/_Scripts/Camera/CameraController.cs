using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;

    public void StartGame()
    {
        virtualCamera.GetCinemachineComponent<CinemachineTransposer>().m_XDamping = 0;
    }

    public void ExitGame()
    {
        virtualCamera.GetCinemachineComponent<CinemachineTransposer>().m_XDamping = 1;
    }
}
