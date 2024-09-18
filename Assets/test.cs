using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public Transform a;


    // Update is called once per frame
    void Update()
    {
        var dir = a.position - this.transform.position;
        Debug.Log(dir.magnitude);
    }
}
