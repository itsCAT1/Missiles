using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateRestartGame : MonoBehaviour
{
    public PlaneManager planeManager;
    public GameObject panelPauseGame;
    public GameObject uiGameControl;
    public Animator animatorButtonPauseInGame;
    public GameObject buttonPauseInGame;
    public GameObject panelEndGame;
    public StateStartGame stateStartGame;

    public void RestartGame()
    {
        var planeInGame = planeManager.planes[planeManager.currentPlaneIndex].GetComponent<Transform>();
        planeInGame.rotation = Quaternion.Euler(0, 0, 180);
        planeInGame.position = Vector3.zero;

        panelPauseGame.SetActive(false);
        uiGameControl.SetActive(true);

        buttonPauseInGame.gameObject.SetActive(true);
        panelEndGame.gameObject.SetActive(false);
        animatorButtonPauseInGame.SetBool("Pause", false);

        planeInGame.gameObject.SetActive(true);

        Time.timeScale = 1;
        stateStartGame.timeCount = 0;
    }
}
