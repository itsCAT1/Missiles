using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerInGame : MonoBehaviour
{
    public DataManager dataManager;
    public GameObject buttonVolumeOnPauseGame;
    public GameObject buttonVolumeOffPauseGame;
    public GameObject buttonVolumeOnEndGame;
    public GameObject buttonVolumeOffEndGame;

    public void Update()
    {
        if (dataManager.data.audioMute)
        {
            AudioListener.pause = true;
            buttonVolumeOnPauseGame.SetActive(false);
            buttonVolumeOffPauseGame.SetActive(true);
            buttonVolumeOnEndGame.SetActive(false);
            buttonVolumeOffEndGame.SetActive(true);
        }
        else
        {
            AudioListener.pause = false;
            buttonVolumeOnPauseGame.SetActive(true);
            buttonVolumeOffPauseGame.SetActive(false);
            buttonVolumeOnEndGame.SetActive(true);
            buttonVolumeOffEndGame.SetActive(false);
        }
    }
    public void PressButtonAudio()
    {
        if (!dataManager.data.audioMute)
        {
            dataManager.data.audioMute = true;
            AudioListener.pause = true;
        }
        else
        {
            dataManager.data.audioMute = false;
            AudioListener.pause = false;
        }
    }
}
