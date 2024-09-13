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

    private void Start()
    {
        StartCoroutine(RandomSpawnStar());
    }

    IEnumerator RandomSpawnStar()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(5, 8));
            Vector3 randomDirection = Random.insideUnitCircle.normalized;
            Vector3 newSpawnStarPos = planePos.position + randomDirection * Random.Range(minSpawnDistance, maxSpawnDistance);

            GameObject newStar = Instantiate(starPrefab, newSpawnStarPos, Quaternion.identity);
            starList.Add(newStar);
            oldSpawnStarPos = newSpawnStarPos;
        }
    }
}
