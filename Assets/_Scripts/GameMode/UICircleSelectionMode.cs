using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICircleSelectionMode : MonoBehaviour
{
    public DataManager dataManager;
    public Transform normalMode;
    public Transform fastMode;

    void Start()
    {
        if (dataManager.data.indexGameMode == 0)
        {
            this.transform.position = normalMode.position;
        }
        else if (dataManager.data.indexGameMode == 1)
        {
            this.transform.position = fastMode.position;
        }
    }
}
