using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateUIBestScore : MonoBehaviour
{
    public Text bestNormalScore;
    public Text bestFastScore;
    public DataManager dataManager;

    void Update()
    {
        bestNormalScore.text = dataManager.data.bestScoreNormalMode.ToString();
        bestFastScore.text = dataManager.data.bestScoreFastMode.ToString();
    }
}
