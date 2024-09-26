using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public Vector3 offSet;
    public bool isCameraControlling = false; 

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
        pos.z = this.transform.localPosition.z;

        this.transform.localPosition = pos;
    }
}
