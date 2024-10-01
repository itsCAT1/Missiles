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
    public int starPoint;
    public int shieldPoint;
    public int havePlane;
    public bool audioMute;
}

[Serializable]
public class ListDataProgress
{
    public List<DataProgress> listDataProgress;
}
