using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerInMenu : MonoBehaviour
{
    public DataManager dataManager;
    public GameObject buttonVolumeOnInMenu;
    public GameObject buttonVolumeOffInMenu;
    public GameObject buttonVolumeOnInOptions;
    public GameObject buttonVolumeOffInOptions;

    public void Update()
    {
        if (dataManager.data.audioMute)
        {
            AudioListener.pause = true;
            buttonVolumeOnInMenu.SetActive(false);
            buttonVolumeOffInMenu.SetActive(true);
            buttonVolumeOnInOptions.SetActive(false);
            buttonVolumeOffInOptions.SetActive(true);
        }
        else
        {
            AudioListener.pause = false;
            buttonVolumeOnInMenu.SetActive(true);
            buttonVolumeOffInMenu.SetActive(false);
            buttonVolumeOnInOptions.SetActive(true);
            buttonVolumeOffInOptions.SetActive(false);
        }
    }
    public void PressButtonAudio()
    {
        if(!dataManager.data.audioMute)
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
