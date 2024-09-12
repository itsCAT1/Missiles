﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateCoinShop : MonoBehaviour
{
    public Text coinText;
    public DataCoin dataCoin = new DataCoin(); // Khởi tạo đối tượng DataCoin

    private void Start()
    {
        LoadCoin();
        UpdateUICoin(); // Cập nhật UI sau khi tải dữ liệu
    }

    private void OnApplicationQuit()
    {
        SaveCoin();
    }

    public void UpdateUICoin()
    {
        coinText.text = dataCoin.coin.ToString(); // Sử dụng đối tượng dataCoin
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
        string defaultValue = JsonUtility.ToJson(new DataCoin());
        string coinDataValueString = PlayerPrefs.GetString(nameof(dataCoin), defaultValue);
        dataCoin = JsonUtility.FromJson<DataCoin>(coinDataValueString); // Gán lại dữ liệu sau khi giải tuần tự
    }
}