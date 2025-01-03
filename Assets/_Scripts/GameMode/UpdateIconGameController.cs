using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateIconGameController : MonoBehaviour
{
    public List<GameObject> iconGameController;
    public DataManager dataManager;

    private void OnEnable()
    {
        if(dataManager.dataBase.indexGameControl == 0)
        {
            iconGameController[0].SetActive(true);
        }
        else if (dataManager.dataBase.indexGameControl == 1)
        {
            iconGameController[1].SetActive(true);
        }
        else if (dataManager.dataBase.indexGameControl == 2)
        {
            iconGameController[2].SetActive(true);
        }
    }
}
