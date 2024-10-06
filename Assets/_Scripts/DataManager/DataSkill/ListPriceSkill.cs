using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SkillBase
{
    public int priceSkill;
}
[CreateAssetMenu(fileName = "ListPriceSkill", menuName = "ScriptableObject/PriceSkill", order = 1)]
public class ListPriceSkill : ScriptableObject
{
    public List<SkillBase> listPriceSkill;
}
