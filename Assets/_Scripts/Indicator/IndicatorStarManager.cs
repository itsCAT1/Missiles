using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorStarManager : MonoBehaviour
{
    public GameObject indicatorStar;
    public List<GameObject> indicatorStarList;
    public StarManager starManager;

    void Update()
    {
        if (starManager.starList.Count > indicatorStarList.Count)
        {
            GameObject newIndicatorStar = Instantiate(indicatorStar, this.transform.position, Quaternion.identity);
            IndicatorStarControl indicatorStarControl = newIndicatorStar.GetComponent<IndicatorStarControl>();
            indicatorStarControl.starPos = starManager.starList[indicatorStarList.Count].transform;

            indicatorStarList.Add(newIndicatorStar);
        }
    }
}
