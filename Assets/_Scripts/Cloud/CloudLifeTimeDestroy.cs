using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudLifeTimeDestroy : MonoBehaviour
{
    public Transform planePos;

    private void Start()
    {
        PlaneController planeController = FindObjectOfType<PlaneController>();
        if (planeController != null)
        {
            planePos = planeController.transform;
        }
    }
    void Update()
    {
        if (Vector3.Distance(planePos.position, this.transform.position) > 10f)
        {
            Destroy(this.gameObject);
        }
    }
}
