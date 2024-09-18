using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missileManager : MonoBehaviour
{
    public GameObject missilePrefab;
    void Start()
    {
        StartCoroutine(start());
    }

    IEnumerator start()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            SpawnMissile();
        }
    }

    void SpawnMissile()
    {
        Vector2 camPos = Camera.main.transform.position;
        Vector2 newPos = Vector2.zero;

        do
        {
            newPos.x = Random.Range(camPos.x - 5, camPos.x + 5);
            newPos.y = Random.Range(camPos.y, camPos.y + 6);
        }
        while ((newPos.x >= camPos.x - 4 && newPos.x <= camPos.x + 4) && (newPos.y >= camPos.y && newPos.y <= camPos.y + 5));
        Instantiate(missilePrefab, newPos, Quaternion.identity);

    }
}
