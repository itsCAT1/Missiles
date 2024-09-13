using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissilesManager : MonoBehaviour
{
    public GameObject missilesPrefab;
    public List<GameObject> missileList;
    public float spawnDistance;
    void Start()
    {
        InvokeRepeating("Spawn", 3f, 8f);
    }

    void Spawn()
    {
        Vector3 randomDirection = Random.insideUnitCircle.normalized;
        Vector3 enemySpawnPos = PlaneController.playerPos.position + randomDirection * spawnDistance;
        GameObject newMissile = Instantiate(missilesPrefab, enemySpawnPos, Quaternion.identity);
        missileList.Add(newMissile);
    }
}
