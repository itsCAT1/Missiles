using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpManager : MonoBehaviour
{
    public Transform planePos;
    Vector3 oldSpawnSpeedUpPos = Vector3.zero;
    public GameObject speedUp;
    public float minSpawnDistance;
    public float maxSpawnDistance;

    private void Start()
    {
        StartCoroutine(RandomSpawnSpeedUp());
    }

    IEnumerator RandomSpawnSpeedUp()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(60,80));
            Vector3 randomDirection = Random.insideUnitCircle.normalized;
            Vector3 newSpawnSpeedUpPos = planePos.position + randomDirection * Random.Range(minSpawnDistance, maxSpawnDistance);

            Instantiate(speedUp, newSpawnSpeedUpPos, Quaternion.identity);
            oldSpawnSpeedUpPos = newSpawnSpeedUpPos;
        }
    }
}
