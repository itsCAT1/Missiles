﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudManager : MonoBehaviour
{
    public Transform planePos;
    Vector3 oldSpawnCloudPos = Vector3.zero;
    public List<GameObject> clouds;
    public float minSpawnDistance;
    public float maxSpawnDistance;

    private void Start()
    {
        StartCoroutine(RandomSpawnCloud());
    }

    IEnumerator RandomSpawnCloud()
    {
        while (true)
        {
            Vector3 randomDirection = Random.insideUnitCircle.normalized;
            Vector3 newSpawnCloudPos = planePos.position + randomDirection * Random.Range(minSpawnDistance, maxSpawnDistance);

            GameObject cloudPrefab = clouds[Random.Range(0, clouds.Count)];
            if(Vector3.Distance(oldSpawnCloudPos, newSpawnCloudPos) > 3)
            {
                Instantiate(cloudPrefab, newSpawnCloudPos, Quaternion.identity);
            }
            oldSpawnCloudPos = newSpawnCloudPos;
            yield return new WaitForSeconds(0.5f);
        }
    }
}
