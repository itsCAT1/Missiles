using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StarManager : MonoBehaviour
{
    public Transform planePos;
    Vector3 oldSpawnStarPos = Vector3.zero;
    public GameObject starPrefab;
    public List<GameObject> starList;
    public float minSpawnDistance;
    public float maxSpawnDistance;

    public float angleOffset;
    private Camera cam;

    private void Start()
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
            Vector3 newSpawnStarPos = planePos.position + randomDirection * Random.Range(minSpawnDistance, maxSpawnDistance);

            GameObject newStar = Instantiate(starPrefab, newSpawnStarPos, Quaternion.identity);
            starList.Add(newStar);
            oldSpawnStarPos = newSpawnStarPos;
        }
    }

    private void Update()
    {
        UpdateTargetIndicator();
    }

    void UpdateTargetIndicator()
    {
        for (int i = 0; i < starList.Count; i++)
        {
            Vector3 viewportPos = cam.WorldToViewportPoint(starList[i].transform.position);

            if ((viewportPos.x < 0 || viewportPos.x > 1 || viewportPos.y < 0 || viewportPos.y > 1))
            {
                GameObject indicator = starList[i].transform.GetChild(0).gameObject;

                if (!indicator.activeSelf)
                {
                    indicator.SetActive(true);
                }

                Vector3 direction = (starList[i].transform.position - cam.transform.position).normalized;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + angleOffset;
                indicator.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

                viewportPos.x = Mathf.Clamp(viewportPos.x, 0.025f, 0.975f);
                viewportPos.y = Mathf.Clamp(viewportPos.y, 0.014f, 0.986f);

                Vector3 indicatorScreenPos = cam.ViewportToWorldPoint(viewportPos);

                indicator.transform.position = indicatorScreenPos;
            }
            else
            {
                GameObject indicator = starList[i].transform.GetChild(0).gameObject;

                if (indicator.activeSelf)
                {
                    indicator.SetActive(false);
                }
            }
        }
    }
}
