using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject missiles;
    public float spawnDistance;
    void Start()
    {
        InvokeRepeating("Spawn", 1f, 2f);
    }

    void Spawn()
    {
        Vector3 randomDirection = Random.insideUnitCircle.normalized;
        Vector3 enemySpawnPos = PlayerController.playerPos.transform.position + randomDirection * spawnDistance;
        Instantiate(missiles, enemySpawnPos, Quaternion.identity);
    }

}
