using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticalLifeTimeDestroy : MonoBehaviour
{
    public float timeDestroy;
    void Start()
    {
        Destroy(this.gameObject, timeDestroy);
    }
}
