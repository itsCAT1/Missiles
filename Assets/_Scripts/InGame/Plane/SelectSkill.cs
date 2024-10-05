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
    public ListSkillBase listSkillBase;
    public ListUISkill listUISkill;

    public ListSkillOwned listSkillOwned; 
    public List<GameObject> uiSkill;
    public PlaneManager planeManager;

    void Start()
    {
        LoadSkillOwned();
        SetPriceSkill();
    }

    public void PurchaseSkill(int index)
    {
        string itemKey = "skillOwned" + index; 

        if (dataManager.dataBase.coin >= listSkillBase.listSkillBase[index].priceSkill && !CheckItem(itemKey))
        {
            dataManager.dataBase.coin -= listSkillBase.listSkillBase[index].priceSkill;

            var itemOwned = new SkillOwned { skillOwned = itemKey };
            listSkillOwned.listSkillOwned.Add(itemOwned);

            Debug.Log(itemOwned);
            SaveSkillOwned();
            uiSkill[index].SetActive(false);
        }
    }

    public bool CheckItem(string itemKey)
    {
        var item = listSkillOwned.listSkillOwned.Find(item => item.skillOwned == itemKey);
        return listSkillOwned.listSkillOwned.Contains(item);
    }
    public void SetPriceSkill()
    {
        for (int i = 0; i < listSkillBase.listSkillBase.Count; i++)
        {
            listUISkill.listUISkill[i].priceText.text = listSkillBase.listSkillBase[i].priceSkill.ToString();
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
