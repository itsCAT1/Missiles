using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DataProgress
{
    public int id;
    public int indexPlane;
    public int indexGameMode;
    public int indexGameControl;
    public int coin;
    public int bestScoreNormalMode;
    public int bestScoreFastMode;
    public int totalPoint;
    public int totalStar;
    public int totalShield;
    public int havePlane;
    public bool audioMute;
    public int totalDay;
}

[Serializable]
public class ListDataProgress
{
    public List<DataProgress> listDataProgress;
}
