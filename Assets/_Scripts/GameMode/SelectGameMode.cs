using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectGameMode : MonoBehaviour
{
    public int gameMode;
    public Animator animatorSelectionCircle;

    public void SelectNormalMode()
    {
        gameMode = 0;

    }
}
