using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudLifeTimeDestroy : MonoBehaviour
{
    void Update()
    {
        if (Vector3.Distance(Camera.main.transform.position, this.transform.position) > 15f)
        {
            Destroy(this.gameObject);
        }
    }
}
