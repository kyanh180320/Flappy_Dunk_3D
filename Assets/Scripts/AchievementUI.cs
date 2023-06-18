using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AchievementUI : MonoBehaviour
{
    public List<AchievementObject> achievementObjects;
    public Sprite btnGray;
    public Sprite btnGreen;
    private void OnEnable()
    {
        Debug.Log("OnEnable");
        int currentHighestScore = GameData.HighestScore;
        foreach (var achievementObj in achievementObjects)
        {
            if (currentHighestScore >= achievementObj.requireScore)
            {
                achievementObj.unlocked = true;
            }
            else
            {
                achievementObj.unlocked = false;
            }
            SetUpAchievementObjUI(achievementObj);
        }
    }

    public void CheckScore()
    {
        int currentHighestScore = GameData.HighestScore;
        foreach (var achievementObj in achievementObjects)
        {
            if (currentHighestScore >= achievementObj.requireScore)
            {
                achievementObj.unlocked = true;
            }
            else
            {
                achievementObj.unlocked = false;
            }
        }
    }

    public bool CheckGiftTypeIsUnlocked(GameGiftType gameGiftType, int index)
    {
        CheckScore();
        foreach (var achievementObj in achievementObjects)
        {
            if (achievementObj.unlocked)
            {
                if (achievementObj.GameGiftType == gameGiftType && achievementObj.giftIndex == index)
                {
                    return true;
                }
            }
        }

        return false;
    }

    public void SetUpAchievementObjUI(AchievementObject achievementObject)
    {
        TextMeshProUGUI tmp = achievementObject.button.transform.GetComponentInChildren<TextMeshProUGUI>();
        if (tmp != null)
        {
            if (achievementObject.unlocked)
            {
                achievementObject.button.GetComponent<Image>().sprite = btnGreen;
                tmp.SetText("Unlocked");
                tmp.fontSize = 42;
            }
            else
            {
                achievementObject.button.GetComponent<Image>().sprite = btnGray;
                tmp.SetText("Locked");
                tmp.fontSize = 50;
            }
        }
    }
}

[Serializable]
public class AchievementObject
{
    public int requireScore;
    public bool unlocked;
    public Button button;
    public GameGiftType GameGiftType;
    public int giftIndex;
    public Sprite achievementIcon;
}

public enum GameGiftType
{
    ChickenSkin,
    CircleSkin
}
