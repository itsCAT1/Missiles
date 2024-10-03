using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpManager : MonoBehaviour
{
    public Transform plane;
    Vector3 oldSpawnSpeedUpPos = Vector3.zero;

    public DataManager dataManager;
    public PlaneManager planeManager;

    public GameObject speedUp;
    public float minSpawnDistance;
    public float maxSpawnDistance;
    Camera cam;

    private void Start()
    {
        plane = planeManager.planes[dataManager.dataBase.indexPlane].GetComponent<Transform>();
        StartCoroutine(RandomSpawnSpeedUp());
        cam = Camera.main;
    }

    IEnumerator RandomSpawnSpeedUp()
    {
        while (true)
        {
            if (!plane.gameObject.activeSelf)
            {
                yield break;
            }
            yield return new WaitForSeconds(Random.Range(20,30));
            Vector3 randomDirection = Random.insideUnitCircle.normalized;
            Vector3 newSpawnSpeedUpPos = cam.transform.position + randomDirection * Random.Range(minSpawnDistance, maxSpawnDistance);
            newSpawnSpeedUpPos.z = 0;

            GameObject newSpeedUp = Instantiate(speedUp, newSpawnSpeedUpPos, Quaternion.identity);
            newSpeedUp.transform.SetParent(this.transform);

            oldSpawnSpeedUpPos = newSpawnSpeedUpPos;
        }
    }
}
