using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCountBegin : MonoBehaviour
{
    public DataManager dataManager;
    public PlaneManager planeManager;
    public Text time;
    public int minutes;
    public int seconds;
    public int timeCount;

    public void StartTimeGame()
    {
        StartCoroutine(TimeCount());
    }

    IEnumerator TimeCount()
    {

        while (true)
        {
            if (!planeManager.planes[dataManager.data.indexPlane].activeSelf)
            {
                yield break;
            }
            timeCount++;
            minutes = Mathf.FloorToInt(timeCount / 60);
            seconds = Mathf.FloorToInt(timeCount % 60);

            time.text = string.Format("{0}:{1:00}", minutes, seconds);

            yield return new WaitForSecondsRealtime(1f);
        }
    }
}
