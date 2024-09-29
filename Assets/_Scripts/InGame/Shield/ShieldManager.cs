﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldManager : MonoBehaviour
{
    public Transform plane;
    public GameObject shieldPrefab;
    public List<GameObject> shieldList;
    public DataPlaneManager dataPlaneManager;
    public PlaneManager planeManager;
    public float minSpawnDistance;
    public float maxSpawnDistance;

    public float angleOffset;
    private Camera cam;

    private void Start()
    {
        plane = planeManager.planes[dataPlaneManager.dataPlane.indexPlane].GetComponent<Transform>();
        StartCoroutine(RandomSpawnShield());
        cam = Camera.main;
    }

    IEnumerator RandomSpawnShield()
    {
        while (true)
        {
            if (!plane.gameObject.activeSelf)
            {
                yield break;
            }
            yield return new WaitForSeconds(Random.Range(30,40));
            Vector3 randomDirection = Random.insideUnitCircle.normalized;
            Vector3 newSpawnShieldPos = cam.transform.position + randomDirection * Random.Range(minSpawnDistance, maxSpawnDistance);

            GameObject newShield = Instantiate(shieldPrefab, newSpawnShieldPos, Quaternion.identity);
            shieldList.Add(newShield);
        }
    }

    private void Update()
    {
        UpdateTargetIndicator();
    }

    void UpdateTargetIndicator()
    {
        for (int i = 0; i < shieldList.Count; i++)
        {
            if (shieldList[i] == null)
            {
                shieldList.RemoveAt(i);
                i--;
                continue;
            }

            Vector3 viewportPos = cam.WorldToViewportPoint(shieldList[i].transform.position);

            if ((viewportPos.x < 0 || viewportPos.x > 1 || viewportPos.y < 0 || viewportPos.y > 1))
            {
                GameObject indicator = shieldList[i].transform.GetChild(0).gameObject;

                if (!indicator.activeSelf)
                {
                    indicator.SetActive(true);
                }

                Vector3 direction = (shieldList[i].transform.position - cam.transform.position).normalized;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + angleOffset;
                indicator.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

                Vector2 posIndicator = shieldList[i].transform.position;
                posIndicator.x = Mathf.Clamp(posIndicator.x, cam.transform.position.x - 2.67f, cam.transform.position.x + 2.67f);
                posIndicator.y = Mathf.Clamp(posIndicator.y, cam.transform.position.y - 4.87f, cam.transform.position.y + 4.87f);

                indicator.transform.position = posIndicator;
            }
            else
            {
                GameObject indicator = shieldList[i].transform.GetChild(0).gameObject;

                if (indicator.activeSelf)
                {
                    indicator.SetActive(false);
                }
            }
        }
    }
}
