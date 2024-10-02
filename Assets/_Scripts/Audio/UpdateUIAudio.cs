using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateUIAudio : MonoBehaviour
{
    public DataManager dataManager;
    public GameObject buttonVolumeOn;
    public GameObject buttonVolumeOff;

    public void OnEnable()
    {
        if (dataManager.dataBase.audioMute)
        {
            AudioListener.pause = true;
            buttonVolumeOn.SetActive(false);
            buttonVolumeOff.SetActive(true);
        }
        else
        {
            AudioListener.pause = false;
            buttonVolumeOn.SetActive(true);
            buttonVolumeOff.SetActive(false);
        }
    }
    public void PressButtonAudio()
    {
        if (!dataManager.dataBase.audioMute)
        {
            dataManager.dataBase.audioMute = true;
            AudioListener.pause = true;
        }
        else
        {
            dataManager.dataBase.audioMute = false;
            AudioListener.pause = false;
        }
    }
}
