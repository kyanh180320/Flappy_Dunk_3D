using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LooseUI : MonoBehaviour
{
    public TextMeshProUGUI currentScore;
    public TextMeshProUGUI highestScore;

    public void SetUp(int score)
    {
        currentScore.SetText(score.ToString());
        highestScore.SetText(GameData.HighestScore.ToString());
    }
}
