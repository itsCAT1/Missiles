using System;
using System.Collections;
using System.Collections.Generic;
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

    public ListSkillOwned listItemOwned; 
    public List<GameObject> uiGameMode;
    public PlaneManager planeManager;

    void Start()
    {
        LoadSkillOwned(); 
        LoadPanel();
    }

    public void PurchaseSkill(int index)
    {
        string itemKey = "skillOwned" + index; 

        if (dataManager.dataBase.coin >= listSkillBase.listSkillBase[index].priceSkill && !CheckItem(itemKey))
        {
            dataManager.dataBase.coin -= listSkillBase.listSkillBase[index].priceSkill;

            var itemOwned = new SkillOwned { skillOwned = itemKey };
            listItemOwned.listSkillOwned.Add(itemOwned);

            Debug.Log(itemOwned);
            SaveSkillOwned();
            uiGameMode[index].SetActive(false);
        }
    }

    public bool CheckItem(string itemKey)
    {
        var item = listItemOwned.listSkillOwned.Find(item => item.skillOwned == itemKey);
        return listItemOwned.listSkillOwned.Contains(item);
    }
    public void LoadPanel()
    {
        for (int i = 0; i < listSkillBase.listSkillBase.Count; i++)
        {
            listUISkill.listUISkill[i].priceText.text = listSkillBase.listSkillBase[i].priceSkill.ToString();
        }
    }

    private void SaveSkillOwned()
    {
        var value = JsonUtility.ToJson(listItemOwned);
        PlayerPrefs.SetString(nameof(ListSkillOwned), value);
        PlayerPrefs.Save();
    }

    private void LoadSkillOwned()
    {
        var value = JsonUtility.ToJson(listItemOwned);
        var valueString = PlayerPrefs.GetString(nameof(ListSkillOwned), value);
        listItemOwned = JsonUtility.FromJson<ListSkillOwned>(valueString);
    }
}
