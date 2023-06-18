using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LooseUI : MonoBehaviour
{
    public Image fillImage;

    public List<int> scoresMilestonesInt;
    public List<TextMeshProUGUI> scoresMilestonesTxt;
    
    public TextMeshProUGUI currentScore;
    public TextMeshProUGUI highestScore;

    public void SetUp(int score)
    {
        currentScore.SetText(score.ToString());
        highestScore.SetText(GameData.HighestScore.ToString());

        scoresMilestonesInt.Clear();
        var achievementObjList = AchievementController.Instance.achievementUI.achievementObjects;
        for (int i = 0; i < achievementObjList.Count; i++)
        {
            if (achievementObjList[i].requireScore <= score && score <= achievementObjList[i + 1].requireScore)
            {
                scoresMilestonesInt.Add(achievementObjList[i].requireScore);
                scoresMilestonesInt.Add(achievementObjList[i+1].requireScore);
                scoresMilestonesInt.Add(achievementObjList[i+2].requireScore);
                scoresMilestonesInt.Add(achievementObjList[i+3].requireScore);
                break;
            }
        }

        for (int i = 0; i < scoresMilestonesTxt.Count; i++)
        {
            scoresMilestonesTxt[i].SetText(scoresMilestonesInt[i].ToString());
        }

        fillImage.fillAmount = (float)(score - scoresMilestonesInt[0]) /
                               (scoresMilestonesInt[scoresMilestonesInt.Count - 1] - scoresMilestonesInt[0]);
    }
}
