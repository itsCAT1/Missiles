using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateRestartGame : MonoBehaviour
{
    public PlaneManager planeManager;
    public GameObject panelPauseGame;

    // Update is called once per frame
    public void RestartGame()
    {
        var planeInGame = planeManager.planes[planeManager.currentPlaneIndex].GetComponent<Transform>();
        planeInGame.rotation = Quaternion.Euler(0, 0, 180);
        panelPauseGame.SetActive(false);
        Time.timeScale = 1;
    }
}
