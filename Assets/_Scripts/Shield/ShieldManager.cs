using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldManager : MonoBehaviour
{
    public Transform planePos;
    Vector3 oldSpawnShieldPos = Vector3.zero;
    public GameObject shieldPrefab;
    public List<GameObject> shieldList;
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
            yield return new WaitForSeconds(Random.Range(3, 5));
            Vector3 randomDirection = Random.insideUnitCircle.normalized;
            Vector3 newSpawnShieldPos = planePos.position + randomDirection * Random.Range(minSpawnDistance, maxSpawnDistance);

            GameObject newShield = Instantiate(shieldPrefab, newSpawnShieldPos, Quaternion.identity);
            shieldList.Add(newShield);
            oldSpawnShieldPos = newSpawnShieldPos;
        }
    }
}
