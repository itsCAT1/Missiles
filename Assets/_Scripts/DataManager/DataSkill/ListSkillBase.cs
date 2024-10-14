using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SkillBase
{
    public int price;
}
[CreateAssetMenu(fileName = "ListSkillBase", menuName = "ScriptableObject/Skills", order = 1)]
public class ListSkillBase : ScriptableObject
{
    public List<SkillBase> skillBases;
}
