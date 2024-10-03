using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SkillBase
{
    public int priceSkill;
}
[CreateAssetMenu(fileName = "ListSkillBase", menuName = "ScriptableObject/Skill", order = 1)]
public class ListSkillBase : ScriptableObject
{
    public List<SkillBase> listSkillBase;
}
