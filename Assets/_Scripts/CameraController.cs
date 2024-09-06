using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public Vector3 offSet;
    
    void Update()
    {
        Vector3 pos = player.position + offSet;
        pos.z = Camera.main.transform.localPosition.z;

        Camera.main.transform.localPosition = pos;
    }
}
