using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class StateRestartGame : MonoBehaviour
{
    public PlaneManager planeManager;
    public DataPlaneManager dataPlaneManager;
    public DataGameplayManager dataGameplayManager;

    public Text time;
    public int minutes;
    public int seconds;
    public int timeCount;

    public void RestartGame()
    {
        StartCoroutine(StartTimeCount());
        for (int i = 0; i < planeManager.planes.Count; i++)
        {
            planeManager.planes[i].SetActive(i == dataPlaneManager.dataPlane.indexPlane);
        }

        if (dataGameplayManager.dataGameplay.indexGameMode == 0)
        {
            Time.timeScale = 1f;
        }
        else if (dataGameplayManager.dataGameplay.indexGameMode == 1)
        {
            Time.timeScale = 1.4f;
        }
    }

    IEnumerator StartTimeCount()
    {
        while (true)
        {
            if (!planeManager.planes[dataPlaneManager.dataPlane.indexPlane].activeSelf)
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
