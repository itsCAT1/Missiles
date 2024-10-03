using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateUIBestScore : MonoBehaviour
{
    public Text bestNormalScore;
    public Text bestFastScore;
    public DataManager dataManager;

    void Start()
    {
        bestNormalScore.text = dataManager.dataBase.bestScoreNormalMode.ToString();
        bestFastScore.text = dataManager.dataBase.bestScoreFastMode.ToString();
    }
}
