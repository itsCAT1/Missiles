using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UpdateUICircleChoice : MonoBehaviour
{
    public RectTransform buttonNormal;
    public RectTransform buttonFast;
    public DataManager dataManager;
    private Coroutine currentAnimation;

    void Start()
    {
        if (dataManager.dataBase.indexGameMode == 0)
        {
            this.transform.position = buttonNormal.position;
        }
        else
            this.transform.position = buttonFast.position;
    }

    public void ChoiceModeNormal()
    {
        if (currentAnimation != null)
            StopCoroutine(currentAnimation);

        currentAnimation = StartCoroutine(AnimationChoiceModeNormal());
    }

    public void ChoiceModeFast()
    {
        if (currentAnimation != null)
            StopCoroutine(currentAnimation);

        currentAnimation = StartCoroutine(AnimationChoiceModeFast());
    }

    IEnumerator AnimationChoiceModeNormal()
    {
        float timeCount = 0;
        float duration = 1;

        while (timeCount < duration)
        {
            timeCount += Time.deltaTime;
            this.transform.position = Vector2.Lerp(this.transform.position, buttonNormal.position, timeCount / duration);
            yield return null;
        }
    }

    IEnumerator AnimationChoiceModeFast()
    {
        float timeCount = 0;
        float duration = 1;

        while (timeCount < duration)
        {
            timeCount += Time.deltaTime;
            this.transform.position = Vector2.Lerp(this.transform.position, buttonFast.position, timeCount / duration);
            yield return null;
        }
    }
}
