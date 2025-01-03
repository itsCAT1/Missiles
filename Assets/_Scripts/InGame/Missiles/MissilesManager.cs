﻿using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Collections;
using UnityEngine;

public class MissilesManager : MonoBehaviour
{
    Transform plane;
    public DataManager dataManager;
    public PlaneManager planeManager;
    public List<GameObject> missilePrefabList;
    public List<GameObject> missileList;
    
    bool isSpawning = true;
    Camera cam;
    void Start()
    {
        plane = planeManager.planes[dataManager.dataBase.indexPlane].GetComponent<Transform>();
        SetTimeSpawn();
        cam = Camera.main;
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
        StartCoroutine(TimeInitGroupMissile());
    }

    IEnumerator TimeInitMissile1()
    {
        yield return new WaitForSeconds(1);
        SpawnMissiles1();
    }

    IEnumerator TimeInitMissile2()
    {
        while (isSpawning)
        {
            yield return new WaitForSeconds(5);
            if (plane.gameObject.activeSelf)
            {
                SpawnMissiles2();
            }
            else
            {
                isSpawning = false;
                yield break;
            }
        }
    }
    IEnumerator TimeInitMissile3()
    {
        while (isSpawning)
        {
            yield return new WaitForSeconds(Random.Range(20,30));
            if (plane.gameObject.activeSelf)
            {
                SpawnMissiles3();
            }
            else
            {
                isSpawning = false;
                yield break;
            }
        }
    }
    IEnumerator TimeInitMissile4()
    {
        while (isSpawning)
        {
            yield return new WaitForSeconds(Random.Range(30, 40));
            if (plane.gameObject.activeSelf)
            {
                SpawnMissiles4();
            }
            else
            {
                isSpawning = false;
                yield break;
            }
        }
    }
    IEnumerator TimeInitMissile5()
    {
        while (isSpawning)
        {
            yield return new WaitForSeconds(Random.Range(40, 50));
            if (plane.gameObject.activeSelf)
            {
                SpawnMissiles5();
            }
            else
            {
                isSpawning = false;
                yield break;
            }
        }
    }
    IEnumerator TimeInitMissile6()
    {
        while (isSpawning)
        {
            yield return new WaitForSeconds(Random.Range(50, 60));
            if (plane.gameObject.activeSelf)
            {
                SpawnMissiles6();
            }
            else
            {
                isSpawning = false;
                yield break;
            }
        }
    }
    IEnumerator TimeInitMissile7()
    {
        while (isSpawning)
        {
            yield return new WaitForSeconds(Random.Range(60, 70));
            if (plane.gameObject.activeSelf)
            {
                SpawnMissiles7();
            }
            else
            {
                isSpawning = false;
                yield break;
            }
        }
    }

    IEnumerator TimeInitGroupMissile()
    {
        while (isSpawning)
        {
            yield return new WaitForSeconds(Random.Range(30, 40));
            int randomTime = Random.Range(1, 4);
            if (plane.gameObject.activeSelf)
            {
                for (int i = 1; i <= randomTime; i++)
                {
                    RandomSpawnGroupMissile();
                }
            }
            else
            {
                isSpawning = false;
                yield break;
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
            newPos.y = Random.Range(planePos.y, planePos.y + 5.5f);
        }
        while ((newPos.x > (planePos.x - 4) && newPos.x < (planePos.x + 4)) && (newPos.y > planePos.y && newPos.y < (planePos.y + 5)));
        var dir = planePos - newPos;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;

        GameObject newMissile1 = Instantiate(missilePrefabList[0], newPos, Quaternion.Euler(0, 0, angle));
        newMissile1.transform.SetParent(this.transform);
    }

    void SpawnMissiles2()
    {
        Vector2 planePos = plane.transform.position;
        Vector2 newPos = Vector2.zero;
        do
        {
            newPos.x = Random.Range(planePos.x - 5, planePos.x + 5);
            newPos.y = Random.Range(planePos.y, planePos.y + 5.5f);
        }
        while ((newPos.x > (planePos.x - 4) && newPos.x < (planePos.x + 4)) && (newPos.y > planePos.y && newPos.y < (planePos.y + 5)));
        var dir = planePos - newPos;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;

        GameObject newMissile2 = Instantiate(missilePrefabList[1], newPos, Quaternion.Euler(0,0,angle));
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
            newPos.y = Random.Range(planePos.y, planePos.y + 5.5f);
        }
        while ((newPos.x > (planePos.x - 4) && newPos.x < (planePos.x + 4)) && (newPos.y > planePos.y && newPos.y < (planePos.y + 5)));
        
        var dir = planePos - newPos;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;

        GameObject newMissile3 = Instantiate(missilePrefabList[2], newPos, Quaternion.Euler(0, 0, angle));
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
            newPos.y = Random.Range(planePos.y, planePos.y + 5.5f);
        }
        while ((newPos.x > (planePos.x - 4) && newPos.x < (planePos.x + 4)) && (newPos.y > planePos.y && newPos.y < (planePos.y + 5)));
        var dir = planePos - newPos;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;

        GameObject newMissile4 = Instantiate(missilePrefabList[3], newPos, Quaternion.Euler(0, 0, angle));
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
            newPos.y = Random.Range(planePos.y, planePos.y + 5.5f);
        }
        while ((newPos.x > (planePos.x - 4) && newPos.x < (planePos.x + 4)) && (newPos.y > planePos.y && newPos.y < (planePos.y + 5)));
        var dir = planePos - newPos;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;

        GameObject newMissile5 = Instantiate(missilePrefabList[4], newPos, Quaternion.Euler(0, 0, angle));
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
            newPos.y = Random.Range(planePos.y, planePos.y + 5.5f);
        }
        while ((newPos.x > (planePos.x - 4) && newPos.x < (planePos.x + 4)) && (newPos.y > planePos.y && newPos.y < (planePos.y + 5)));
        var dir = planePos - newPos;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;

        GameObject newMissile6 = Instantiate(missilePrefabList[5], newPos, Quaternion.Euler(0, 0, angle));
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
            newPos.y = Random.Range(planePos.y, planePos.y + 5.5f);
        }
        while ((newPos.x > (planePos.x - 4) && newPos.x < (planePos.x + 4)) && (newPos.y > planePos.y && newPos.y < (planePos.y + 5)));
        var dir = planePos - newPos;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;

        GameObject newMissile7 = Instantiate(missilePrefabList[6], newPos, Quaternion.Euler(0, 0, angle));
        missileList.Add(newMissile7);
        newMissile7.transform.SetParent(this.transform);
    }

    void RandomSpawnGroupMissile()
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

            Vector3 viewportPos = cam.WorldToViewportPoint(missileList[i].transform.position);

            if ((viewportPos.x < 0 || viewportPos.x > 1 || viewportPos.y < 0 || viewportPos.y > 1))
            {
                GameObject indicator = missileList[i].transform.GetChild(0).gameObject;

                if (!indicator.activeSelf)
                {
                    indicator.SetActive(true);
                }

                if (!plane.gameObject.activeSelf)
                {
                    indicator.SetActive(false);
                }

                Vector2 posIndicator = missileList[i].transform.position;
                posIndicator.x = Mathf.Clamp(posIndicator.x, cam.transform.position.x - 2.67f, cam.transform.position.x + 2.67f);
                posIndicator.y = Mathf.Clamp(posIndicator.y, cam.transform.position.y - 4.87f, cam.transform.position.y + 4.87f);

                Vector2 direction = ((Vector2)missileList[i].transform.position - posIndicator).normalized;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
                indicator.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

                indicator.transform.position = posIndicator;
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
