using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorShieldManager : MonoBehaviour
{
    public GameObject indicatorShield;
    public List<GameObject> indicatorShieldList;
    public ShieldManager shieldManager;

    void Update()
    {
        if (shieldManager.shieldList.Count > indicatorShieldList.Count)
        {
            GameObject newIndicatorShield = Instantiate(indicatorShield, this.transform.position, Quaternion.identity);
            IndicatorShieldControl indicatorShieldControl = newIndicatorShield.GetComponent<IndicatorShieldControl>();
            indicatorShieldControl.shieldPos = shieldManager.shieldList[indicatorShieldList.Count].transform;

            indicatorShieldList.Add(newIndicatorShield);
        }
    }
}
