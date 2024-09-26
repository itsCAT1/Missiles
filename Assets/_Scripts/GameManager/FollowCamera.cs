using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Camera mainCamera; 
    public Canvas canvas;     

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    void FixedUpdate()
    {
        Vector3 pos = mainCamera.transform.position;
        pos.z = 0;
        canvas.transform.position = pos;
    }
}
