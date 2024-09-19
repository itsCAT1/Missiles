using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    void FixedUpdate()
    {
        Vector3 pos = this.transform.position;
        pos = Camera.main.transform.position;
        pos.z = 0;
        Debug.Log($"camera: {Camera.main.transform.position}");
        Debug.Log($"pos: {pos}");
        this.transform.position = pos;
    }
}
