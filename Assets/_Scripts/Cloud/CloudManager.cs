using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudManager : MonoBehaviour
{
    public Transform planePos;
    Vector3 oldSpawnCloudPos = Vector3.zero;
    public List<GameObject> clouds;
    public float minSpawnDistance;
    public float maxSpawnDistance;

    private void Start()
    {
        StartCoroutine(RandomSpawnCloud());
    }

    IEnumerator RandomSpawnCloud()
    {
        while (true)
        {
            Vector3 randomDirection = Random.insideUnitCircle.normalized;
            Vector3 newSpawnCloudPos = Camera.main.transform.position + randomDirection * Random.Range(minSpawnDistance, maxSpawnDistance);
            newSpawnCloudPos.z = 0;

            GameObject cloudPrefab = clouds[Random.Range(0, clouds.Count)];
            if(Vector3.Distance(oldSpawnCloudPos, newSpawnCloudPos) > 3)
            {
                GameObject newCloud = Instantiate(cloudPrefab, newSpawnCloudPos, Quaternion.identity);

                newCloud.transform.SetParent(this.transform);
            }
            oldSpawnCloudPos = newSpawnCloudPos;
            yield return new WaitForSeconds(0.4f);
        }
    }
}
