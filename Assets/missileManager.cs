using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missileManager : MonoBehaviour
{
    public GameObject missilePrefab;
    public List<GameObject> missilePrefabList;
    public List<GameObject> missileList;
    public float a, b, c, d;
    void Start()
    {
        StartCoroutine(start());
    }

    IEnumerator start()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            SpawnMissile();
        }
        
    }

    void SpawnMissile()
    {
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        Vector2 newPos = (Vector2)Camera.main.transform.position + randomDirection * Random.Range(5,6);
        GameObject newMissile = Instantiate(missilePrefabList[0], newPos, Quaternion.identity);
        missileList.Add(newMissile);
    }

    private void Update()
    {
        UpdateIndicator();
    }

    void UpdateIndicator()
    {
        for(int i =0; i<missileList.Count; i++)
        {
            Vector3 misPos = missileList[i].transform.position;
            if(misPos.x < Camera.main.transform.position.x - 2.82 || misPos.x > Camera.main.transform.position.x + 2.82 
                || misPos.y < Camera.main.transform.position.y - 5 || misPos.y > Camera.main.transform.position.y + 5)
            {
                Debug.Log("ngoai");
                GameObject indicator = missileList[i].transform.GetChild(0).gameObject;
                if (!indicator.activeSelf)
                {
                    indicator.SetActive(true);
                }
                Vector3 direction = (missileList[i].gameObject.transform.position - Camera.main.transform.position).normalized;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
                indicator.transform.rotation = Quaternion.Euler(0,0,angle);

                misPos.x = Mathf.Clamp(misPos.x, a , b);
                misPos.y = Mathf.Clamp(misPos.y, c , d);

                Vector3 indicatorPos = misPos;

                indicator.transform.position = indicatorPos;
            }
            else
            {
                Debug.Log("trong");
                GameObject indicator = missileList[i].transform.GetChild(0).gameObject;
                if (indicator.activeSelf)
                {
                    indicator.SetActive(false);
                }
            }
        }
        
    }
}
