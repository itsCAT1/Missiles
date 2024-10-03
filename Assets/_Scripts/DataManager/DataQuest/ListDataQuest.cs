using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ListDataQuest", menuName = "ScriptableObject/Quests", order = 1)]
public class ListDataQuest : ScriptableObject
{
    public List<DailyQuestData> questData;
}
