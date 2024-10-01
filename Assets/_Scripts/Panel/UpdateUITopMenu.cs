using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateUITopMenu : MonoBehaviour
{
    public GameObject uiTopMenu;
    public GameObject uiMidMenu;


    public void Start()
    {
        uiTopMenu.SetActive(true);
        uiMidMenu.SetActive(true);
    }
}
