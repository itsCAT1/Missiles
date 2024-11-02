using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectGameMode : MonoBehaviour
{
    public DataManager dataManager;

    public void SelectNormalMode()
    {
        dataManager.dataBase.indexGameMode = 0;
    }

    public void SelectFastMode()
    {
        dataManager.dataBase.indexGameMode = 1;
    }
}
