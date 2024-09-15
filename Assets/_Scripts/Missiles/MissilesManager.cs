using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Collections;
using UnityEngine;

public class MissilesManager : MonoBehaviour
{
    public Transform planePos;
    public GameObject missilesPrefab;
    Vector3 oldSpawnMissilePos = Vector3.zero;
    public List<GameObject> missileList;
    public float minSpawnDistance;
    public float maxSpawnDistance;

    public float angleOffset;
    private Camera cam;

    void Start()
    {
        StartCoroutine(RandomSpawnStar());
        cam = Camera.main;
    }

    IEnumerator RandomSpawnStar()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(3, 5));
            Vector3 randomDirection = Random.insideUnitCircle.normalized;
            Vector3 newSpawnMissilePos = planePos.position + randomDirection * Random.Range(minSpawnDistance, maxSpawnDistance);

            GameObject newMissile = Instantiate(missilesPrefab, newSpawnMissilePos, Quaternion.identity);
            missileList.Add(newMissile);
            oldSpawnMissilePos = newSpawnMissilePos;
        }
    }

    private void Update()
    {
        UpdateTargetIndicator();
    }

    void UpdateTargetIndicator()
    {
        for (int i = 0; i < missileList.Count; i++)
        {
            if (missileList[i] == null)
            {
                missileList.RemoveAt(i);
                i--; 
                continue;
            }

            Vector3 viewportPos = cam.WorldToViewportPoint(missileList[i].transform.position);

            if ((viewportPos.x < 0 || viewportPos.x > 1 || viewportPos.y < 0 || viewportPos.y > 1))
            {
                GameObject indicator = missileList[i].transform.GetChild(0).gameObject;

                if (!indicator.activeSelf)
                {
                    indicator.SetActive(true);
                }

                Vector3 direction = (missileList[i].transform.position - cam.transform.position).normalized;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + angleOffset;
                indicator.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

                viewportPos.x = Mathf.Clamp(viewportPos.x, 0.025f, 0.975f);
                viewportPos.y = Mathf.Clamp(viewportPos.y, 0.014f, 0.986f);

                Vector3 indicatorScreenPos = cam.ViewportToWorldPoint(viewportPos);

                indicator.transform.position = indicatorScreenPos;
            }
            else
            {
                GameObject indicator = missileList[i].transform.GetChild(0).gameObject;

                if (indicator.activeSelf)
                {
                    indicator.SetActive(false);
                }
            }
        }
    }
}
