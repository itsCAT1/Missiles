using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGroupStar : MonoBehaviour
{
    void Update()
    {
        bool allActive = false;

        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            if (child.gameObject.activeSelf)
            {
                allActive = true;
                break;
            }
        }

        if (!allActive)
        {
            Destroy(gameObject);
        }
    }
}
