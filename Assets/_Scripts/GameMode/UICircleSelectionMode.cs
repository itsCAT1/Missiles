﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICircleSelectionMode : MonoBehaviour
{
    public DataGameplayManager dataGameplayManager;
    public Transform normalMode;
    public Transform fastMode;

    void Start()
    {
        if (dataGameplayManager.dataGameplay.indexGameMode == 0)
        {
            this.transform.position = normalMode.position;
        }
        else if (dataGameplayManager.dataGameplay.indexGameMode == 1)
        {
            this.transform.position = fastMode.position;
        }
    }
}