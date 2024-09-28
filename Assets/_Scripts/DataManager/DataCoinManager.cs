﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[Serializable]
public class DataCoin
{
    public int coin;
}
public class DataCoinManager : MonoBehaviour
{
    public Text coinText;
    public DataCoin dataCoin = new DataCoin(); 

    private void Start()
    {
        LoadCoin();
        UpdateUICoin(); 
    }

    private void OnApplicationQuit()
    {
        SaveCoin();
    }

    public void UpdateUICoin()
    {
        coinText.text = dataCoin.coin.ToString();
    }

    public void ButtonReceive25000()
    {
        dataCoin.coin += 25000;
        UpdateUICoin();
        SaveCoin();
    }

    public void ButtonReceive80000()
    {
        dataCoin.coin += 80000;
        UpdateUICoin();
        SaveCoin();
    }

    public void ButtonReceive150000()
    {
        dataCoin.coin += 150000;
        UpdateUICoin();
        SaveCoin();
    }

    public void SaveCoin()
    {
        string value = JsonUtility.ToJson(dataCoin);
        PlayerPrefs.SetString(nameof(dataCoin), value);
        PlayerPrefs.Save();
    }

    public void LoadCoin()
    {
        string value = JsonUtility.ToJson(new DataCoin());
        string coinValueString = PlayerPrefs.GetString(nameof(dataCoin), value);
        dataCoin = JsonUtility.FromJson<DataCoin>(coinValueString);
    }
}
