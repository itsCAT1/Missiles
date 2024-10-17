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
        dataManager.LoadDataBase();
        UpdateUICoin(); 
    }

    public void UpdateUICoin()
    {
        coinText.text = dataManager.dataBase.coin.ToString();
    }

    public void ButtonReceive25000()
    {
        dataManager.dataBase.coin += 25000;
        UpdateUICoin();
    }

    public void ButtonReceive80000()
    {
        dataManager.dataBase.coin += 80000;
        UpdateUICoin();
    }

    public void ButtonReceive150000()
    {
        dataManager.dataBase.coin += 150000;
        UpdateUICoin();
    }
}

