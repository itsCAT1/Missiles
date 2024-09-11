using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudLifeTimeDestroy : MonoBehaviour
{
    public float timeDestroy = 10f;
    void Start()
    {
        Destroy(gameObject, timeDestroy);
    }
}
