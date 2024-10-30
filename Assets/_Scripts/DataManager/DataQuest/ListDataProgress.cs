using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DataProgress
{
    public int id;
    public int currentValue;
}

[Serializable]
public class ListDataProgress
{
    public List<DataProgress> dataProgresses;
}
