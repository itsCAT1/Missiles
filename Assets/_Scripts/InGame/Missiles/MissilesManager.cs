using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Collections;
using UnityEngine;

public class MissilesManager : MonoBehaviour
{
    public Transform plane;
    public PlaneManager planeManager;
    public GameObject missilesPrefab;
    public List<GameObject> missilePrefabList;
    public List<GameObject> missileList;
    public float minSpawnDistance;
    public float maxSpawnDistance;
    
    public float angleOffset;

    void Start()
    {
        SetTimeSpawn();
        
        for(int i = 0; i < planeManager.planes.Count; i++)
        {
            plane = planeManager.planes[planeManager.currentPlaneIndex].GetComponent<Transform>();
        }
    }

    void SetTimeSpawn()
    {
        StartCoroutine(TimeInitMissile1());
        StartCoroutine(TimeInitMissile2());
        StartCoroutine(TimeInitMissile3());
        StartCoroutine(TimeInitMissile4());
        StartCoroutine(TimeInitMissile5());
        StartCoroutine(TimeInitMissile6());
        StartCoroutine(TimeInitMissile7());
        StartCoroutine(TimeRandomSpawnMissile());
    }

    IEnumerator TimeInitMissile1()
    {
        yield return new WaitForSeconds(1);
        SpawnMissiles1();
    }
    IEnumerator TimeInitMissile2()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);
            SpawnMissiles2();
        }
    }
    IEnumerator TimeInitMissile3()
    {
        while (true)
        {
            yield return new WaitForSeconds(30);
            SpawnMissiles3();
        }
    }
    IEnumerator TimeInitMissile4()
    {
        while (true)
        {
            yield return new WaitForSeconds(60);
            SpawnMissiles4();
        }
    }
    IEnumerator TimeInitMissile5()
    {
        while (true)
        {
            yield return new WaitForSeconds(90);
            SpawnMissiles5();
        }
    }
    IEnumerator TimeInitMissile6()
    {
        while (true)
        {
            yield return new WaitForSeconds(120);
            SpawnMissiles6();
        }
    }
    IEnumerator TimeInitMissile7()
    {
        while (true)
        {
            yield return new WaitForSeconds(150);
            SpawnMissiles7();
        }
    }

    IEnumerator TimeRandomSpawnMissile()
    {
        while (true)
        {
            yield return new WaitForSeconds(40);
            int randomTime = Random.Range(1, 4);
            for(int i = 1; i <= randomTime; i++)
            {
                RandomSpawnMissile();
            }
        }
    }

    void SpawnMissiles1()
    {
        Vector2 planePos = plane.transform.position;
        Vector2 newPos = Vector2.zero;
        do
        {
            newPos.x = Random.Range(planePos.x - 5, planePos.x + 5);
            newPos.y = Random.Range(planePos.y, planePos.y + 7);
        }
        while ((newPos.x > (planePos.x - 4) && newPos.x < (planePos.x + 4)) && (newPos.y > planePos.y && newPos.y < (planePos.y + 6)));
        GameObject newMissile1 = Instantiate(missilePrefabList[0], newPos, Quaternion.identity);
        missileList.Add(newMissile1);
        newMissile1.transform.SetParent(this.transform);
    }

    void SpawnMissiles2()
    {
        Vector2 planePos = plane.transform.position;
        Vector2 newPos = Vector2.zero;
        do
        {
            newPos.x = Random.Range(planePos.x - 5, planePos.x + 5);
            newPos.y = Random.Range(planePos.y, planePos.y + 7);
        }
        while ((newPos.x > (planePos.x - 4) && newPos.x < (planePos.x + 4)) && (newPos.y > planePos.y && newPos.y < (planePos.y + 6)));
        GameObject newMissile2 = Instantiate(missilePrefabList[1], newPos, Quaternion.identity);
        missileList.Add(newMissile2);
        newMissile2.transform.SetParent(this.transform);
    }

    void SpawnMissiles3()
    {
        Vector2 planePos = plane.transform.position;
        Vector2 newPos = Vector2.zero;
        do
        {
            newPos.x = Random.Range(planePos.x - 5, planePos.x + 5);
            newPos.y = Random.Range(planePos.y, planePos.y + 7);
        }
        while ((newPos.x > (planePos.x - 4) && newPos.x < (planePos.x + 4)) && (newPos.y > planePos.y && newPos.y < (planePos.y + 6)));
        GameObject newMissile3 = Instantiate(missilePrefabList[2], newPos, Quaternion.identity);
        missileList.Add(newMissile3);
        newMissile3.transform.SetParent(this.transform);
    }

    void SpawnMissiles4()
    {
        Vector2 planePos = plane.transform.position;
        Vector2 newPos = Vector2.zero;
        do
        {
            newPos.x = Random.Range(planePos.x - 5, planePos.x + 5);
            newPos.y = Random.Range(planePos.y, planePos.y + 7);
        }
        while ((newPos.x > (planePos.x - 4) && newPos.x < (planePos.x + 4)) && (newPos.y > planePos.y && newPos.y < (planePos.y + 6)));
        GameObject newMissile4 = Instantiate(missilePrefabList[3], newPos, Quaternion.identity);
        missileList.Add(newMissile4);
        newMissile4.transform.SetParent(this.transform);
    }

    void SpawnMissiles5()
    {
        Vector2 planePos = plane.transform.position;
        Vector2 newPos = Vector2.zero;
        do
        {
            newPos.x = Random.Range(planePos.x - 5, planePos.x + 5);
            newPos.y = Random.Range(planePos.y, planePos.y + 7);
        }
        while ((newPos.x > (planePos.x - 4) && newPos.x < (planePos.x + 4)) && (newPos.y > planePos.y && newPos.y < (planePos.y + 6)));
        GameObject newMissile5 = Instantiate(missilePrefabList[4], newPos, Quaternion.identity);
        missileList.Add(newMissile5);
        newMissile5.transform.SetParent(this.transform);
    }

    void SpawnMissiles6()
    {
        Vector2 planePos = plane.transform.position;
        Vector2 newPos = Vector2.zero;
        do
        {
            newPos.x = Random.Range(planePos.x - 5, planePos.x + 5);
            newPos.y = Random.Range(planePos.y, planePos.y + 7);
        }
        while ((newPos.x > (planePos.x - 4) && newPos.x < (planePos.x + 4)) && (newPos.y > planePos.y && newPos.y < (planePos.y + 6)));
        GameObject newMissile6 = Instantiate(missilePrefabList[5], newPos, Quaternion.identity);
        missileList.Add(newMissile6);
        newMissile6.transform.SetParent(this.transform);
    }

    void SpawnMissiles7()
    {
        Vector2 planePos = plane.transform.position;
        Vector2 newPos = Vector2.zero;
        do
        {
            newPos.x = Random.Range(planePos.x - 5, planePos.x + 5);
            newPos.y = Random.Range(planePos.y, planePos.y + 7);
        }
        while ((newPos.x > (planePos.x - 4) && newPos.x < (planePos.x + 4)) && (newPos.y > planePos.y && newPos.y < (planePos.y + 6)));
        GameObject newMissile7 = Instantiate(missilePrefabList[6], newPos, Quaternion.identity);
        missileList.Add(newMissile7);
        newMissile7.transform.SetParent(this.transform);
    }

    void RandomSpawnMissile()
    {
        Vector2 oldPos = Vector2.zero;
        Vector2 planePos = plane.transform.position;
        Vector2 newPos = Vector2.zero;

        newPos.x = Random.Range(planePos.x - 3, planePos.x + 3);
        newPos.y = planePos.y + 7;

        Vector2 direction = planePos - newPos;
        Quaternion rotate = transform.rotation;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - Random.Range(60, 80);
        rotate.eulerAngles = new Vector3(0, 0, angle);

        if (Vector2.Distance(oldPos, newPos) > 3)
        {
            GameObject newRandomMissile = Instantiate(missilePrefabList[7], newPos, rotate);
            missileList.Add(newRandomMissile);
            newRandomMissile.transform.SetParent(this.transform);
        }
        oldPos = newPos;
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

            Vector3 viewportPos = Camera.main.WorldToViewportPoint(missileList[i].transform.position);

            if ((viewportPos.x < 0 || viewportPos.x > 1 || viewportPos.y < 0 || viewportPos.y > 1))
            {
                GameObject indicator = missileList[i].transform.GetChild(0).gameObject;

                if (!indicator.activeSelf)
                {
                    indicator.SetActive(true);
                }

                Vector3 direction = (missileList[i].transform.position - Camera.main.transform.position).normalized;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + angleOffset;
                indicator.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

                viewportPos.x = Mathf.Clamp(viewportPos.x, 0.025f, 0.975f);
                viewportPos.y = Mathf.Clamp(viewportPos.y, 0.014f, 0.986f);

                Vector3 indicatorScreenPos = Camera.main.ViewportToWorldPoint(viewportPos);

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
