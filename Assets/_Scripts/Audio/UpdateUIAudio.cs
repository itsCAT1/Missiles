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
        if (dataManager.data.audioMute)
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
