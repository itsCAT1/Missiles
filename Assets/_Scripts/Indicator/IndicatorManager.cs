using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorManager : MonoBehaviour
{
    public GameObject indicatorShield;
    public List<GameObject> indicatorShieldList;
    public int indexIndicator = 0;
    public ShieldManager shieldManager;

    private void Update()
    {
        if (shieldManager.shieldList.Count > indicatorShieldList.Count)
        {
            GameObject newIndicator = Instantiate(indicatorShield, this.transform.position, Quaternion.identity);
            IndicatorControl indicatorControl = newIndicator.GetComponent<IndicatorControl>();
            indicatorControl.shieldPos = shieldManager.shieldList[indicatorShieldList.Count].transform;

            indicatorShieldList.Add(indicatorShield);
            indexIndicator++;
        }

    }
}
