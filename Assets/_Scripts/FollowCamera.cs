using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    void Update()
    {
        this.transform.position = Camera.main.transform.position;
    }
}