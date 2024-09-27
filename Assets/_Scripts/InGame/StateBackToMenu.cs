using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StateBackToMenu : MonoBehaviour
{
    public void BackToHome()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
