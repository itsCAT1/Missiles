using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StarManager : MonoBehaviour
{
    public Transform plane;
    public GameObject starPrefab;
    public List<GameObject> groupPrefabStar;
    public List<GameObject> starList;

    public DataManager dataManager;
    public PlaneManager planeManager;

    public float minSpawnDistance;
    public float maxSpawnDistance;

    private Camera cam;

    private void Start()
    {
        plane = planeManager.planes[dataManager.dataBase.indexPlane].GetComponent<Transform>();
        StartCoroutine(RandomSpawnStar());
        StartCoroutine(RandomSpawnGroupStar());
        cam = Camera.main;
    }

    IEnumerator RandomSpawnStar()
    {
        while (true)
        {
            if (!plane.gameObject.activeSelf)
            {
                yield break;
            }
            yield return new WaitForSeconds(Random.Range(10,20));
            Vector3 randomDirection = Random.insideUnitCircle.normalized;
            Vector3 starPos = cam.transform.position + randomDirection * 
                Random.Range(minSpawnDistance, maxSpawnDistance);
            starPos.z = 0;

            GameObject newStar = Instantiate(starPrefab, starPos, Quaternion.identity);
            newStar.transform.SetParent(this.transform);
            starList.Add(newStar);
        }
    }

    IEnumerator RandomSpawnGroupStar()
    {
        while (true)
        {
            if (!plane.gameObject.activeSelf)
            {
                yield break;
            }
            yield return new WaitForSeconds(Random.Range(30, 50));
            Vector3 randomDirection = Random.insideUnitCircle.normalized;
            Vector3 groupStarPos = cam.transform.position + randomDirection *
                Random.Range(10, 15);
            groupStarPos.z = 0;

            GameObject newGroupStar = Instantiate(groupPrefabStar[Random.Range(0, groupPrefabStar.Count-1)], groupStarPos, Quaternion.identity);
            Debug.Log(newGroupStar);
            newGroupStar.transform.SetParent(this.transform);
            starList.Add(newGroupStar);
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
            if (starList[i] == null)
            {
                starList.RemoveAt(i);
                i--;
                continue;
            }

            

            Vector3 viewportPos = cam.WorldToViewportPoint(starList[i].transform.position);

            if ((viewportPos.x < 0 || viewportPos.x > 1 || viewportPos.y < 0 || viewportPos.y > 1))
            {
                GameObject indicator = starList[i].transform.GetChild(0).gameObject;

                if (!indicator.activeSelf)
                {
                    indicator.SetActive(true);
                }

                if (!plane.gameObject.activeSelf)
                {
                    indicator.SetActive(false);
                }

                Vector3 direction = (starList[i].transform.position - plane.transform.position).normalized;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
                indicator.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

                Vector2 posIndicator = starList[i].transform.position;
                posIndicator.x = Mathf.Clamp(posIndicator.x, cam.transform.position.x - 2.67f, cam.transform.position.x + 2.67f);
                posIndicator.y = Mathf.Clamp(posIndicator.y, cam.transform.position.y - 4.87f, cam.transform.position.y + 4.87f);

                indicator.transform.position = posIndicator;
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
