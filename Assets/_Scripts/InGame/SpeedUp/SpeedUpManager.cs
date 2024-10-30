using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpManager : MonoBehaviour
{
    public Transform plane;
    Vector3 oldSpawnSpeedUpPos = Vector3.zero;

    public DataManager dataManager;
    public PlaneManager planeManager;

    public List<GameObject> speedUpList;
    public GameObject speedUpPrefab;

    public float minSpawnDistance;
    public float maxSpawnDistance;
    Camera cam;

    private void Start()
    {
        plane = planeManager.planes[dataManager.dataBase.indexPlane].GetComponent<Transform>();
        StartCoroutine(RandomSpawnSpeedUp());
        cam = Camera.main;
    }

    IEnumerator RandomSpawnSpeedUp()
    {
        while (true)
        {
            if (!plane.gameObject.activeSelf)
            {
                yield break;
            }
            yield return new WaitForSeconds(Random.Range(20,30));
            Vector3 randomDirection = Random.insideUnitCircle.normalized;
            Vector3 newSpawnSpeedUpPos = cam.transform.position + randomDirection * Random.Range(minSpawnDistance, maxSpawnDistance);
            newSpawnSpeedUpPos.z = 0;

            if (!plane.transform.GetChild(1).gameObject.activeSelf)
            {
                GameObject newSpeedUp = Instantiate(speedUpPrefab, newSpawnSpeedUpPos, Quaternion.identity);
                newSpeedUp.transform.SetParent(this.transform);
                speedUpList.Add(newSpeedUp);
            }
        }
    }

    private void Update()
    {
        UpdateTargetIndicator();
    }

    void UpdateTargetIndicator()
    {
        for (int i = 0; i < speedUpList.Count; i++)
        {
            if (speedUpList[i] == null)
            {
                speedUpList.RemoveAt(i);
                i--;
                continue;
            }

            Vector3 viewportPos = cam.WorldToViewportPoint(speedUpList[i].transform.position);

            if ((viewportPos.x < 0 || viewportPos.x > 1 || viewportPos.y < 0 || viewportPos.y > 1))
            {
                GameObject indicator = speedUpList[i].transform.GetChild(0).gameObject;

                if (!indicator.activeSelf)
                {
                    indicator.SetActive(true);
                }

                if (!plane.gameObject.activeSelf)
                {
                    indicator.SetActive(false);
                }

                Vector3 direction = (speedUpList[i].transform.position - plane.transform.position).normalized;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
                indicator.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

                Vector2 posIndicator = speedUpList[i].transform.position;
                posIndicator.x = Mathf.Clamp(posIndicator.x, cam.transform.position.x - 2.67f, cam.transform.position.x + 2.67f);
                posIndicator.y = Mathf.Clamp(posIndicator.y, cam.transform.position.y - 4.87f, cam.transform.position.y + 4.87f);

                indicator.transform.position = posIndicator;
            }
            else
            {
                GameObject indicator = speedUpList[i].transform.GetChild(0).gameObject;

                if (indicator.activeSelf)
                {
                    indicator.SetActive(false);
                }
            }
        }
    }
}
