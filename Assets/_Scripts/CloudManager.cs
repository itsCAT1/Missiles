using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudManager : MonoBehaviour
{
    [SerializeField] Transform playerPos;
    [SerializeField] Transform oldgroupCloud;
    [SerializeField] Transform newgroupCloud;
    float min = 2700f;
    float max = 4700f;

    private void Update()
    {
        Vector3 AP = playerPos.position - oldgroupCloud.position;
        Vector3 BP = playerPos.position - newgroupCloud.position;
        if (AP.sqrMagnitude > min && BP.sqrMagnitude < max)
        {
            oldgroupCloud.gameObject.SetActive(true);
            newgroupCloud.gameObject.SetActive(true);
        }

        if (AP.sqrMagnitude > max && BP.sqrMagnitude < min)
        {
            oldgroupCloud.gameObject.SetActive(false);
            newgroupCloud.gameObject.SetActive(true);
        }

        if (AP.sqrMagnitude < max && BP.sqrMagnitude > min)
        {
            oldgroupCloud.gameObject.SetActive(true);
            newgroupCloud.gameObject.SetActive(true);
        }

        if (AP.sqrMagnitude < min && BP.sqrMagnitude > max)
        {
            oldgroupCloud.gameObject.SetActive(true);
            newgroupCloud.gameObject.SetActive(false);
        }

    }
}

