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
    public int indexShield = 0;
    Camera cam;

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
            indexShield++;
            oldSpawnShieldPos = newSpawnShieldPos;
        }
    }

    void IndicatorShield()
    {
        Vector3 screenPos = cam.WorldToViewportPoint(shieldList[indexShield].transform.position);

        // Kiểm tra nếu đối tượng ở ngoài tầm nhìn của camera
        if (screenPos.z < 0 || screenPos.x < 0 || screenPos.x > 1 || screenPos.y < 0 || screenPos.y > 1)
        {
            if (!shieldList[indexShield].transform.GetChild(0))
            {
                shieldList[indexShield].transform.GetChild(0).set;
            }

            // Xác định hướng từ player tới target
            Vector3 direction = (shieldList[indexShield].transform.position - cam.transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + angleOffset;
            Indicator.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

            Vector3 targetWorldPos = Target.transform.position;

            // Giới hạn vị trí của chỉ báo theo World Point (chiều ngang 5.5, chiều dọc 10)
            targetWorldPos.x = Mathf.Clamp(targetWorldPos.x, -horizontalLimit, horizontalLimit);
            targetWorldPos.y = Mathf.Clamp(targetWorldPos.y, -verticalLimit, verticalLimit);

            Indicator.transform.position = targetWorldPos;
        }
        else
        {
            if (Indicator.activeSelf)
            {
                Indicator.SetActive(false);
            }
        }
    }
}
