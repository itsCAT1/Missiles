using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissilesManager : MonoBehaviour
{
    public GameObject missiles;
    public float spawnDistance;
    void Start()
    {
        InvokeRepeating("Spawn", 3f, 8f);
    }

    void Spawn()
    {
        Vector3 randomDirection = Random.insideUnitCircle.normalized;
        Vector3 enemySpawnPos = PlaneController.playerPos.position + randomDirection * spawnDistance;
        Instantiate(missiles, enemySpawnPos, Quaternion.identity);
    }
}
