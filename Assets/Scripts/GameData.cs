using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData
{
    public static int ChickenSkinIndex
    {
        get
        {
            return PlayerPrefs.GetInt("ChickenSkinIndex", 0);
        }
        set
        {
            PlayerPrefs.SetInt("ChickenSkinIndex", value);
        }
    }

    public static int HighestScore
    {
        get
        {
            return PlayerPrefs.GetInt("HighestScore", 0);
        }
        set
        {
            PlayerPrefs.SetInt("HighestScore", value);
        }
    }
    
    public static int PlayCount
    {
        get
        {
            return PlayerPrefs.GetInt("PlayCount", 0);
        }
        set
        {
            PlayerPrefs.SetInt("PlayCount", value);
        }
    }
    
    public static int LockSpawnCooldown
    {
        get
        {
            return PlayerPrefs.GetInt("LockSpawnCooldown", 0);
        }
        set
        {
            PlayerPrefs.SetInt("LockSpawnCooldown", value);
        }
    }
}
