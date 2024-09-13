using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorMissileManager : MonoBehaviour
{
    public GameObject indicatorMissile;
    public List<GameObject> indicatorMissileList;
    public MissilesManager missilesManager;
    
    void Update()
    {
        if(missilesManager.missileList.Count > indicatorMissileList.Count)
        {
            GameObject newIndicatorMissile = Instantiate(indicatorMissile, this.transform.position, Quaternion.identity);
            IndicatorMissileControl indicatorMissileControl = newIndicatorMissile.GetComponent<IndicatorMissileControl>();
            indicatorMissileControl.missilePos = missilesManager.missileList[indicatorMissileList.Count].transform;

            indicatorMissileList.Add(newIndicatorMissile);
        }
    }
}
