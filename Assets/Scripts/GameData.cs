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
}
