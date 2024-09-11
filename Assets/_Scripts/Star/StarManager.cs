using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StarManager : MonoBehaviour
{
    public Transform planePos;
    Vector3 oldSpawnStarPos = Vector3.zero;
    public GameObject star;
    public float minSpawnDistance;
    public float maxSpawnDistance;

    private void Start()
    {
        StartCoroutine(RandomSpawnShield());
    }

    IEnumerator RandomSpawnShield()
    {
        while (true)
        {
            Vector3 randomDirection = Random.insideUnitCircle.normalized;
            Vector3 newSpawnStarPos = planePos.position + randomDirection * Random.Range(minSpawnDistance, maxSpawnDistance);

            Instantiate(star, newSpawnStarPos, Quaternion.identity);
            oldSpawnStarPos = newSpawnStarPos;
            yield return new WaitForSeconds(Random.Range(5,7));
        }
    }
}
