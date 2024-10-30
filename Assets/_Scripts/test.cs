using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public DataManager dataManager;

    private void OnApplicationPause(bool pause)
    {
        if(pause)
        {
            dataManager.SaveDataBase();
        }
    }
}
