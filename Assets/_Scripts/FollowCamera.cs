using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform planePos;

    void Update()
    {
        this.transform.position = planePos.position;
    }
}
