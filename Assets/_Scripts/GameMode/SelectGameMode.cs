using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectGameMode : MonoBehaviour
{
    public DataGameplayManager dataGameplayManager;
    public Animator animatorSelectionCircle;

    void Start()
    {
        if (dataGameplayManager.dataGameplay.indexGameMode == 0)
        {
            animatorSelectionCircle.SetFloat("Base", 0);
        }
        else if (dataGameplayManager.dataGameplay.indexGameMode == 1)
        {
            animatorSelectionCircle.SetFloat("Base", 1);
        }
    }

    public void SelectNormalMode()
    {
        dataGameplayManager.dataGameplay.indexGameMode = 0;
        StartCoroutine(TimeAnimationNormalMode());
    }

    public void SelectFastMode()
    {
        dataGameplayManager.dataGameplay.indexGameMode = 1;
        StartCoroutine (TimeAnimationFastMode());
    }

    IEnumerator TimeAnimationNormalMode()
    {
        animatorSelectionCircle.SetBool("NormalMode", true);
        yield return new WaitForSeconds(0.5f);
        animatorSelectionCircle.SetBool("NormalMode", false);
        animatorSelectionCircle.SetFloat("Base", 0);
    }

    IEnumerator TimeAnimationFastMode()
    {
        animatorSelectionCircle.SetBool("FastMode", true);
        yield return new WaitForSeconds(0.5f);
        animatorSelectionCircle.SetBool("FastMode", false);
        animatorSelectionCircle.SetFloat("Base", 1);
    }
}
