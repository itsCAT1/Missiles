using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ShieldManager : MonoBehaviour
{
    public Transform planePos;
    Vector3 oldSpawnShieldPos = Vector3.zero;
    public GameObject shieldPrefab;
    public List<GameObject> shieldList;
    public float minSpawnDistance;
    public float maxSpawnDistance;

    public float angleOffset;
    private Camera cam;

    private void Start()
    {
        StartCoroutine(RandomSpawnShield());
        cam = Camera.main;
    }

    IEnumerator RandomSpawnShield()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(3, 5));
            Vector3 randomDirection = Random.insideUnitCircle.normalized;
            Vector3 newSpawnShieldPos = planePos.position + randomDirection * Random.Range(minSpawnDistance, maxSpawnDistance);

            GameObject newShield = Instantiate(shieldPrefab, newSpawnShieldPos, Quaternion.identity);
            shieldList.Add(newShield);
            oldSpawnShieldPos = newSpawnShieldPos;
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

                viewportPos.x = Mathf.Clamp(viewportPos.x, 0.025f, 0.975f);
                viewportPos.y = Mathf.Clamp(viewportPos.y, 0.014f, 0.986f);

                Vector3 indicatorScreenPos = cam.ViewportToWorldPoint(viewportPos);

                indicator.transform.position = indicatorScreenPos;
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
