using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public Transform planePos;

    void Update()
    {
        var camPos = planePos.position;
        camPos.z = -10f;
        this.transform.position = camPos;
    }
}
