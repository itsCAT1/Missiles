using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[Serializable]
public class UIPriceSkill
{
    public Text priceUI;
}

public class ListUIPriceSkill : MonoBehaviour
{
    public List<UIPriceSkill> UIPriceSkills;
}