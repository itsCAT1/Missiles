using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartInGame : MonoBehaviour
{
    public TimeCountBegin timeCountBegin;
    void Start()
    {
        timeCountBegin.StartTimeGame();
    }
}
