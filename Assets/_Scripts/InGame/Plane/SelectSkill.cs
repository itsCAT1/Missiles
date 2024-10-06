using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;


[Serializable]
public class SkillOwned
{
    public string skillOwned; 
}

[Serializable]
public class ListSkillOwned
{
    public List<SkillOwned> listSkillOwned; 
}

public class SelectSkill : MonoBehaviour
{

    public DataManager dataManager;
    public ListPriceSkill listPriceSkill;
    public ListUIPriceSkill listUIPriceSkill;

    public ListSkillOwned listSkillOwned; 
    public List<GameObject> uiSkill;
    public PlaneManager planeManager;
    public GameObject modeUI;

    void Start()
    {
        LoadSkillOwned();
        
        for (int i = 0; i < planeManager.planes.Count; i++)
        {
            listUIPriceSkill.listUIPriceSkill[i].priceText.text =
                    listPriceSkill.listPriceSkill[i].priceSkill.ToString();
        }
    }

    public void PurchaseSkill(int index)
    {
        string itemKey = "skillOwned" + index; 

        if (dataManager.dataBase.coin >= listPriceSkill.listPriceSkill[index].priceSkill && !CheckItem(itemKey))
        {
            dataManager.dataBase.coin -= listPriceSkill.listPriceSkill[index].priceSkill;

            var itemOwned = new SkillOwned { skillOwned = itemKey };
            listSkillOwned.listSkillOwned.Add(itemOwned);

            Debug.Log(itemOwned);
            SaveSkillOwned();
            uiSkill[index].SetActive(false);
            modeUI.SetActive(true);
        }
    }

    public bool CheckItem(string itemKey)
    {
        var item = listSkillOwned.listSkillOwned.Find(item => item.skillOwned == itemKey);
        return listSkillOwned.listSkillOwned.Contains(item);
    }
    public void LoadSkill()
    {
        int indexPlane = dataManager.dataBase.indexPlane;  // Lấy chỉ số máy bay hiện tại
        string itemKey = "skillOwned" + indexPlane;  

        if (indexPlane > 0)
        {
            // Kiểm tra xem skill của máy bay này đã được mua chưa
            if (!CheckItem(itemKey))
            {
                // Nếu chưa được mua, hiển thị UI skill và tắt UI mode
                for (int i = 1; i < planeManager.planes.Count; i++)
                {
                    // Hiển thị UI skill của máy bay hiện tại
                    uiSkill[i].SetActive(i == indexPlane);
                }
                modeUI.SetActive(false);  // Tắt UI mode khi chưa mua skill
            }
            else
            {
                // Nếu skill đã được mua, tắt UI skill và bật UI mode
                for (int i = 1; i < planeManager.planes.Count; i++)
                {
                    uiSkill[i].SetActive(false);  // Tắt UI skill cho tất cả các máy bay
                }
                modeUI.SetActive(true);  // Bật UI mode khi skill đã mua
            }
        }
        else
        {
            modeUI.SetActive(true); 
        }
    }


    private void SaveSkillOwned()
    {
        var value = JsonUtility.ToJson(listSkillOwned);
        PlayerPrefs.SetString(nameof(ListSkillOwned), value);
        PlayerPrefs.Save();
    }

    private void LoadSkillOwned()
    {
        var value = JsonUtility.ToJson(listSkillOwned);
        var valueString = PlayerPrefs.GetString(nameof(ListSkillOwned), value);
        listSkillOwned = JsonUtility.FromJson<ListSkillOwned>(valueString);
    }
}
