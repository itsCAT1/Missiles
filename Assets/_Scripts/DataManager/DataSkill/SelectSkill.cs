using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;


[Serializable]
public class SkillOwned
{
    public int id;
    public bool havePlane;
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
    public ListUIPriceSkill listUIPriceSkill;

    public ListSkillOwned listSkillOwned; 
    public List<GameObject> uiSkill;
    public PlaneManager planeManager;
    public GameObject modeUI;

    public DataCoinManager dataCoinManager;

    private void Update()
    {
        LoadSkillOwned();
        for (int i = 0; i < planeManager.planes.Count; i++)
        {
            listUIPriceSkill.UISkills[i].priceUI.text =
                    listSkillBase.skillBases[i].price.ToString();
        }
    }

    private void OnApplicationQuit()
    {
        SaveSkillOwned();
    }

    public bool CheckPlane(int id)
    {
        foreach (var skillOwned in listSkillOwned.listSkillOwned)
        {
            if (skillOwned.id == id && skillOwned.havePlane)
            {
                return true;
            }
        }
        return false;
    }

    public void PurchasePlane(int id)
    {
        if (dataManager.dataBase.coin >= listSkillBase.skillBases[id].price && !CheckPlane(id))
        {
            dataManager.dataBase.coin -= listSkillBase.skillBases[id].price;
            var itemOwned = new SkillOwned
            {
                id = id,
                havePlane = true,
            };
            listSkillOwned.listSkillOwned.Add(itemOwned);

            dataCoinManager.UpdateUICoin();
            SaveSkillOwned();
            uiSkill[id].SetActive(false);
            modeUI.SetActive(true);
        }
    }

    public void LoadSkill()
    {
        int id = dataManager.dataBase.indexPlane;
        if (id > 0)
        {
            if (!CheckPlane(id))
            {
                for (int i = 0; i < planeManager.planes.Count; i++)
                {
                    uiSkill[i].SetActive(i == id);
                }
                modeUI.SetActive(false);  
            }
            else
            {
                for (int i = 0; i < planeManager.planes.Count; i++)
                {
                    uiSkill[i].SetActive(false);  
                }
                modeUI.SetActive(true);  
            }
        }
        else
        {
            for (int i = 0; i < planeManager.planes.Count; i++)
            {
                uiSkill[i].SetActive(false);
            }
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

