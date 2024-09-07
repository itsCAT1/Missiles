using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text timeCount;
    public GameObject star;
    Vector2 oldPos = Vector2.zero;
    private void Start()
    {
        StartCoroutine(StartTimeCount());
        StartCoroutine(SpawnStar());
    }

    IEnumerator StartTimeCount()
    {
        while (true)
        {
            int minutes = Mathf.FloorToInt(Time.time / 60);
            int seconds = Mathf.FloorToInt(Time.time % 60);

            timeCount.text = string.Format("{0}:{1:00}", minutes, seconds);

            yield return new WaitForSeconds(1f);
        }
    }


    IEnumerator SpawnStar()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(3,7));

            Vector2 screenSize = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

            Vector2 newPos = Vector2.zero;
            do
            {
                newPos.x = Random.Range(-screenSize.x - 5, screenSize.x + 5);
                newPos.y = Random.Range(-screenSize.y - 5, screenSize.y + 5);
            }
            while ((newPos.x >= -screenSize.x && newPos.x <= screenSize.x) ||
            (newPos.y >= -screenSize.y && newPos.y <= screenSize.y) ||
            Vector2.Distance(newPos, oldPos) < 2);

            oldPos = newPos;

            Instantiate(star, newPos, Quaternion.identity);
        } 
    }
}
