using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DataCoinManager : MonoBehaviour
{
    public Text coinText;
    public DataManager dataManager;
    private void Start()
    {
        dataManager.LoadData();
        UpdateUICoin(); 
    }

    public void UpdateUICoin()
    {
        coinText.text = dataManager.data.coin.ToString();
    }

    public void ButtonReceive25000()
    {
        dataManager.data.coin += 25000;
        UpdateUICoin();
    }

    public void ButtonReceive80000()
    {
        dataManager.data.coin += 80000;
        UpdateUICoin();
    }

    public void ButtonReceive150000()
    {
        dataManager.data.coin += 150000;
        UpdateUICoin();
    }
}

