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
        animatorSelectionCircle.SetTrigger("NormalMode");
    }

    public void SelectFastMode()
    {
        gameMode = 1;
        animatorSelectionCircle.SetTrigger("FastMode");
    }
}
