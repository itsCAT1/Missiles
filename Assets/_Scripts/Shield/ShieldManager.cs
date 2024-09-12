using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldManager : MonoBehaviour
{
    public Transform planePos;
    Vector3 oldSpawnShieldPos = Vector3.zero;
    public GameObject shield;
    public List<GameObject> shieldList;
    public int indexShield = 0;
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
            yield return new WaitForSeconds(Random.Range(1, 2));
            Vector3 randomDirection = Random.insideUnitCircle.normalized;
            Vector3 newSpawnShieldPos = planePos.position + randomDirection * Random.Range(minSpawnDistance, maxSpawnDistance);

            Instantiate(shield, newSpawnShieldPos, Quaternion.identity);
            shieldList.Add(shield);
            indexShield++;
            oldSpawnShieldPos = newSpawnShieldPos;
        }
    }
}
